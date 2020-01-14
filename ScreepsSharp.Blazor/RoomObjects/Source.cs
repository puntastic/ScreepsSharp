using ScreepSharp.Core;
using ScreepSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class Source : ARoomObject, ISource
	{
		public Source(string id) : base(id) { }

		public int energy => Game.InvokeById<int>(id, "energy");
		public int energyCapacity => Game.InvokeById<int>(id, "energyCapacity");
		public int ticksToRegeneration => Game.InvokeById<int>(id, "ticksToRegeneration");
	}
}
