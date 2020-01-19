using ScreepsSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
	public class Memory : IMemory
	{
		private string _path;
		private IJsInterop _js;

		public Memory(string path, IJsInterop js)
		{
			_path = path;
			_js = js;
		}

		public T GetOrDefault<T>(string key)
		{
			if (!_js.TryGet(_path, key, out T value)) { return default; }
			return value;
		}

		public bool TrySet<T>(string key, T value) { return _js.TrySet(_path, key, value); }
	}
}
