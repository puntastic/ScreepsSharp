using ScreepsSharp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core.RoomObjects
{
	public interface ICreepBase : IRoomObject, IHasStore
	{
		string name { get; }
		IMemory memory { get; }
		//todo:

		Result MoveTo(RoomPosition target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false);
		Result MoveTo(IRoomObject target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false);
		Result Say(string message, bool publiclyVisible = false);
	}
}
