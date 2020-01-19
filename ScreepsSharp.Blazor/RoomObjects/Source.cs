using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class Source : ARoomObject, ISource
	{
		public Source(string id, IJsInterop js) : base(id, js) { }

		public int energy => _js.InvokeById<int>(id, "energy");
		public int energyCapacity => _js.InvokeById<int>(id, "energyCapacity");
		public int ticksToRegeneration => _js.InvokeById<int>(id, "ticksToRegeneration");
	}
}
