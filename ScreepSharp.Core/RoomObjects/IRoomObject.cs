using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core.RoomObjects
{
    public interface IRoomObject
    {
        // not all room objects have an id but i'm bumping this down a level for ease
        // of inheritence
        string id { get; }
        IRoom room { get; }
        RoomPosition pos { get; }
        IEffect effects { get; }
        bool my { get; }
    }
}
