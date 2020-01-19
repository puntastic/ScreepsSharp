using Mono.WebAssembly.Interop;
using ScreepsSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
	public class BlazorJSRuntime : MonoWebAssemblyJSRuntime, IJsInterop
	{
		private static BlazorJSRuntime _instance;

		//// They removed jsruntime.current... so i'll make my own jsruntime....
		public static BlazorJSRuntime Current
		{
			get
			{
				if (_instance == null)
				{
					_instance = new BlazorJSRuntime();
					Initialize(_instance);
				}

				return _instance;
			}
		}

		protected BlazorJSRuntime() { }

		public void InvokeVoid(string identifier, params object[] args) { _ = Invoke<object>(identifier, args); }

		public T InvokeById<T>(string id, string target) { return Invoke<T>("invokeByObjId", id, target, null); }
		public T InvokeById<T>(string id, string target, params object[] args) { return Invoke<T>("invokeByObjId", id, target, args); }

		public bool TryGet<T>(string path, string key, out T value)
		{
			try
			{
				value = Invoke<T>("getValue", path, key);
				return true;
			}
			catch (Exception ex) { WriteLine(ex.ToString()); }//temprarily want to see any issues that pop up so they can be fixed

			value = default;
			return false;
		}

		public bool TrySet<T>(string path, string key, T value) { return Invoke<bool>("setValue", new object[] { path, key, value }); }
		public T Get<T>(string path, string key) { return TryGet(path, key, out T value) ? value : default; }

		[Obsolete("I want to remove this when I figure out interop improvements")]
		public string[] GetKeys(string path) { return Invoke<string[]>("getKeys", path) ?? new string[] { }; }//return TryGet("getKeys", out string[] value) ? value : new string[0]; }

		public void WriteLine(string line) { InvokeVoid("console.log", line); }

		

	}


}
