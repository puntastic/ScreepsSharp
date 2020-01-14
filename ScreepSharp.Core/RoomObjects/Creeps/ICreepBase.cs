using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core.RoomObjects
{
    public interface ICreepBase : IRoomObject, IHasStore
    {
        string name { get; }

        //todo: purpose made memory type
        Dictionary<string, object> memory { get; }

        Result MoveTo(RoomPosition target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false);
        Result MoveTo(IRoomObject target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false);
        Result Say (string message, bool publiclyVisible = false);
    }
}
