using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ScreepsSharp.Core
{
    public interface IGame : IDisposable
    {
        IJsInterop js { get; }
        event EventHandler tickStarted;

        int time { get; }

        IReadOnlyDictionary<string, ICreep> creeps { get; }
        IReadOnlyDictionary<string, IRoom> rooms { get; }

        ICpu cpu { get; }

        void OnTickStart();
        void WriteLine(string line);
    }
}
