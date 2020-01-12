using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ScreepSharp.Core
{
    // can't say I like singletons but if you can Game.creeps in screeps
    // I want to damn well be able to here
    public static class Game
    {
        public static int time => _instance.time;
        public static ReadOnlyDictionary<string, ICreep> creeps => _instance.creeps;
        public static ReadOnlyDictionary<string, IRoom> rooms => _instance.rooms;
        public static event EventHandler tickStarted 
        { 
            add { _instance.tickStarted += value;  } 
            remove { _instance.tickStarted -= value; }
        }

        public static IJsInterop js => _instance.js;

        private static IGame _instance;

        public static void Init(IGame game)
        {
            if (_instance != null) { throw new InvalidOperationException("Game already initialized"); }
            _instance = game;
        }

        public static void OnTickStart() { }
    }
}
