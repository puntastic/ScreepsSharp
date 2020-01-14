using ScreepSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ScreepSharp.Core
{
    public interface IGame
    {
        void OnTickStart(EventArgs e);
        event EventHandler tickStarted;

        T Invoke<T>(string target, params object[] args);
        T InvokeById<T>(string id, string target);// { return default; }
        T InvokeById<T>(string id, string target, params object[] args);// { return default; }

        IJsInterop js { get; }
        int time { get; }

        ReadOnlyDictionary<string, ICreep> creeps { get; }
        ReadOnlyDictionary<string, IRoom> rooms { get; }
    }
}
