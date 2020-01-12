const JsZip = Utils.LoadModule('jszip-sync.min');

module.exports =
{
	Unzip: function (filename)
	{
		let jsZip = new JsZip();
		let compressed = Utils.LoadModule(filename);
		let uncompressed = {};

		if (!compressed) { return null; }		

		//todo: this looks terrible
		jsZip.sync(() =>
			jsZip.loadAsync(compressed)
				.then((zipped) =>
					_.each(zipped.files, (value, key) =>
						zipped
							.file(key)
							.async(this.LoadType(key))
							.then((data) => uncompressed[key] = data)
					)
				)
		);

		return uncompressed;
	},

	LoadType(filename)
	{
	//	console.log(filename + "|" + _.last(filename.split(".")).toLowerCase());
		switch (_.last(filename.split(".")).toLowerCase())
		{
			case "pdb":
			case "json":
				return "string";
			case "wasm":
			case "dll":
		//	default:
				return "arrayBuffer";
		}

		return null;
	}
}