"use strict";

const ZipHandler = Utils.LoadModule('zip-handler');
//const Overrides = Utils.LoadModule('mono-overrides');

//todo: refactor
function bindStaticMethod(assembly, typeName, method)
{
	let fqn = `[${assembly}] ${typeName}:${method}`;
	return Module.mono_bind_static_method(fqn);
}

//todo: refactor
function attachInteropInvoker()
{
	var dotNetDispatcherInvokeMethodHandle = bindStaticMethod('Mono.WebAssembly.Interop', 'Mono.WebAssembly.Interop.MonoWebAssemblyJSRuntime', 'InvokeDotNet');
	var dotNetDispatcherBeginInvokeMethodHandle = bindStaticMethod('Mono.WebAssembly.Interop', 'Mono.WebAssembly.Interop.MonoWebAssemblyJSRuntime', 'BeginInvokeDotNet');
	var dotNetDispatcherEndInvokeJSMethodHandle = bindStaticMethod('Mono.WebAssembly.Interop', 'Mono.WebAssembly.Interop.MonoWebAssemblyJSRuntime', 'EndInvokeJS');

	DotNet.attachDispatcher(
		{
			beginInvokeDotNetFromJS: function (callId, assemblyName, methodIdentifier, dotNetObjectId, argsJson) 
			{
				if (!dotNetObjectId && !assemblyName) { throw new Error('Either assemblyName or dotNetObjectId must have a non null value.'); }

				// As a current limitation, we can only pass 4 args. Fortunately we only need one of
				// 'assemblyName' or 'dotNetObjectId', so overload them in a single slot
				const assemblyNameOrDotNetObjectId = dotNetObjectId ? dotNetObjectId.toString() : assemblyName;

				dotNetDispatcherBeginInvokeMethodHandle(
					callId ? callId.toString() : null,
					assemblyNameOrDotNetObjectId,
					methodIdentifier,
					argsJson,
				);
			},
			endInvokeJSFromDotNet: function (asyncHandle, succeeded, serializedArgs) { dotNetDispatcherEndInvokeJSMethodHandle(serializedArgs); },
			invokeDotNetFromJS: function (assemblyName, methodIdentifier, dotNetObjectId, argsJson)
			{
				return dotNetDispatcherInvokeMethodHandle(
					assemblyName ? assemblyName : null,
					methodIdentifier,
					dotNetObjectId ? dotNetObjectId.toString() : null,
					argsJson,
				);
			},
		});

}


//todo: refactor this into submodules
module.exports = class MonoLoader
{
	constructor(moduleOptions)
	{
		if (!moduleOptions) { moduleOptions = {}; }

		this._OverrideModuleVal(moduleOptions, 'instantiateWasm', this._RecieveInstanceInfo);
		this._OverrideModuleVal(moduleOptions, 'onRuntimeInitialized', this._OnRuntimeInitialized);

		//mono expects this to exist
		//console.warn = console.log;
		global.print = console.log.bind(console);

		// something about the screeps environment necessitates this
		// there may be a more elegant solution but until I investigate
		// this is the only way to get a 'Module' var into mono.js
		//
		// ...In addition to removing 
		// 'var Module=typeof Module!=="undefined"?Module:{};'
		//  at the start of the file.
		global.Module = moduleOptions;
	}

	_OverrideModuleVal(overriding, key, val, force)
	{
		if (overriding[key] && !force) { return; }
		overriding[key] = typeof val === "function" ? val.bind(this) : val;
	}

	Tick()
	{
		if (!this.IsReady() && !this.TryInit()) { return; }
		Module.mono_call_assembly_entry_point(this._config.entryAssembly, 'asd');
	}

	// We need to stagger as much loading across multiple ticks as possible.
	//
	// It's just too easy to wipe out the entire cpu allocation of even large 
	// empires (300cpu + 500bucket) partway through the initialization process.
	TryInit()
	{
		if (this._initFailed) { return false; }
		if (this.IsReady()) { return true; }

		if (Game.cpu.bucket < 1000)
		{
			console.log("ScreepsSharp: bucket low! Waiting for a tick.");
			return false;
		}

		if(!this.Set('_binaries', () => ZipHandler.Unzip('compressed.zip'))) { return false; }
		if (!this.Set('_monoModule', () => new WebAssembly.Module(this._binaries['mono.wasm']))) { return false; }
		if (!this.Set('_config', () => JSON.parse(this._binaries['blazor.boot.json']))) { return false; }
		if(!this.Set('_monoJs', () => Utils.LoadModule('mono'))) { return false; }
		if (!this.Set('_monoInstance', () => new WebAssembly.Instance(this._monoModule, this._instanceInfo))) { return false; }

		if (this._onMonoInstantiated) { this._onMonoInstantiated(this._monoInstance); }
		this._ready = true;

		console.log("ScreepsSharp: Loading done.");
	}

	IsReady() { return this._ready; }


	Set(varName, func)
	{
		if (this[varName]) { return true; }

		try
		{
			this[varName] = func();
			console.log(`ScreepsSharp: ${varName} initialized.`);

			return false;
		}
		catch (ex)
		{
			this._initFailed = true;
			console.log(`ScreepsSharp: Creation of ${varName} failed: \n ${ex.message}\n${ex.stack}`);
			throw ex;
		}
		
		return false;
	}

	_RecieveInstanceInfo(info, onMonoInstantiated, enableDebugging)
	{
		this._instanceInfo = info;
		this._onMonoInstantiated = onMonoInstantiated;
		this._enableDeubbing = enableDebugging;

		return false;
	}

	_OnRuntimeInitialized()
	{
		let allLoaded = true;
		let loadedFiles = [];

		let addAssembly = Module.cwrap('mono_wasm_add_assembly', null, ['string', 'number', 'number']);
		let loadRuntime = Module.cwrap('mono_wasm_load_runtime', null, ['string', 'number']);

		for (let filename of this._config.assemblies)
		{

			let runDependencyId = `blazor:${filename}`;
			Module['addRunDependency'](runDependencyId);

			if (!this._TryInstantiateDependency(filename, addAssembly))
			{
				allLoaded = false;
				continue;
			}

			Module['removeRunDependency'](runDependencyId);
			loadedFiles.push(filename);
		}

		if (!allLoaded)
		{
			console.log("ScreepsSharp: One or more modules failed to instantiate. Aborting mono init...");
			return;
		}

	//	MONO.loaded_files = loadedFiles;

		loadRuntime(this._fsRoot || "", this._isDebugging || 0);
		attachInteropInvoker();

	//	MONO.mono_wasm_runtime_is_ready = true;
	}

	_TryInstantiateDependency(filename, addAssembly)
	{
		let binary = this._binaries[filename];
		if (!binary)
		{
			console.log(`ScreepsSharp: Could not find ${filename}`);

			// don't want to fail a load attempt because a definition file isn't there
			return _.last(filename.split(".") === 'pdb');
		}

		var asm = new Uint8Array(binary)
		var memory = Module._malloc(asm.length);
		var heapBytes = new Uint8Array(Module.HEAPU8.buffer, memory, asm.length);

		heapBytes.set(asm);
		addAssembly(filename, memory, asm.length);

		console.log(`ScreepsSharp: Loaded ${filename}`);

		return true;
	}
}