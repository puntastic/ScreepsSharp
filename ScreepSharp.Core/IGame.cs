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
        IJsInterop js { get; }
        int time { get; }
        ReadOnlyDictionary<string, ICreep> creeps { get; }
        ReadOnlyDictionary<string, IRoom> rooms { get; }
    }
}
