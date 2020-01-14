using ScreepSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core
{
    public interface IRoom
    {
        string name { get; }
        IController controller { get; }
        IRoomObject[] Find(Find type);
        
    }
}
