using Mono.WebAssembly.Interop;
using ScreepSharp.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
    public class BlazorGame : IGame
    {
        public IJsInterop js => ScreepsJSRuntime.Current;

        private int _lastUpdate;

        private Dictionary<string, ICreep> _creeps = new Dictionary<string, ICreep>();
        public ReadOnlyDictionary<string, ICreep> creeps { get; }

        private Dictionary<string, IRoom> _rooms = new Dictionary<string, IRoom>();
        public ReadOnlyDictionary<string, IRoom> rooms { get; }

        public int time => js.Invoke<int>("Game.time");

        public event EventHandler tickStarted;
        public void OnTickStart(EventArgs e) { Update(); }

        public BlazorGame()
        {
             rooms = new ReadOnlyDictionary<string, IRoom>(_rooms);
            creeps = new ReadOnlyDictionary<string, ICreep>(_creeps);
        }
   

        private void Update()
        {
            if(_lastUpdate == time) { return; }
            var creepNames = js.Invoke<string[]>("bindings.creepNames");
            
            //todo: persistence
            _creeps.Clear();
            foreach(var name in creepNames) { _creeps.Add(name, new Creep(name)); }
        }

    }
}