using System;
using System.Collections.Generic;
using System.Text;

//using System.Text.Json;
//using System.Text.Json.Serialization;

using Newtonsoft.Json;

namespace ScreepSharp.Core
{
    public class RoomPosition
    {
        int x { get; }
        int y { get; }
        string roomName { get; }

        [JsonConstructor]
        public RoomPosition(int x, int y, string roomName)
        {
            this.x = x;
            this.y = y;
            this.roomName = roomName;
        }

    }
}
