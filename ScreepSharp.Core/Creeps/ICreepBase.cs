using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core
{
    public interface ICreepBase : IRoomObject
    {
        string name { get; }
        int MoveTo(RoomPosition target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false);
    }
}
