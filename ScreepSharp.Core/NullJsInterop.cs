using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core
{
	public class NullJsInterop : IJsInterop
	{

		public T Invoke<T>(string identifier, params object[] args) { return default; }

		public T InvokeById<T>(string id, string target) { return default; }
		public T InvokeById<T>(string id, string target, params object[] args) { return default; }

		public void InvokeVoid(string identifier, params object[] args) { }

		public string[] GetKeys(string path) { return new string[] { }; }

		public void WriteLine(string line) { }

		public bool TrySet<T>(string path, string key, T value) { return false; }
		public bool TryGet<T>(string path, string key, out T value)
		{
			value = default;
			return false;
		}

		

		public T Get<T>(string path, string key) { return default; }
	}
}
