using ScreepsSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
	public class Memory : IMemory
	{
		private string _id;

		public Memory(string id)
		{
			_id = id;
		}

		public object this[string index]
		{
			get { return Game.Invoke<object>("getMemoryByObjId", _id, index ); }
			set { Game.js.InvokeVoid("setMemoryByObjId", _id, index, value); }
		}
	}
}
