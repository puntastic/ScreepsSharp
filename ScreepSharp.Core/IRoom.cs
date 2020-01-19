using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core
{
    public interface IRoom
    {
        string name { get; }
        
        IController controller { get; }

        IMemory memory { get; }

        IRoomObject[] Find(Find type);
        
    }
}
