using ScreepsSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
	public class Cpu : ICpu
	{
		public float bucket => _js.Get<float>("Game.cpu", "bucket");
		public float limit => _js.Get<float>("Game.cpu", "limit");

		private IJsInterop _js { get; }
		public Cpu(IJsInterop js) { _js = js; }

		public float getUsed() { return _js.Invoke<float>("Game.cpu.getUsed"); }
	}
}


//Game.cpu.bucket
//Game.cpu.getUsed() >= Game.cpu.limit