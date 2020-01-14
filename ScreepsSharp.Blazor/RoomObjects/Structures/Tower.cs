using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class Tower : StructureWithStore, ITower
	{
		public Tower(string id) : base(id) { }

		public Result Attack(IRoomObject target)
		{
			return (Result)Game.InvokeById<int>(id, "_attack", target.id);
		}

		public Result Repair(IRoomObject target)
		{
			return (Result)Game.InvokeById<int>(id, "_repair", target.id);
		}
	}
}
