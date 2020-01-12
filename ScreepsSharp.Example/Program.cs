using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.JSInterop;
using ScreepSharp.Core;
using ScreepsSharp.Blazor;
using System.Linq;

namespace ScreepsSharp.Example
{
    public class Program
    {
        private static bool _initialized = false;
        private static void Log(string s) { Game.js.InvokeVoid("console.log", s); }
        public static void Main(string[] args)
        {
            if (!_initialized)
            {
                Game.Init(new BlazorGame());
                _initialized = true;
            }

            Game.OnTickStart();
            var js = Game.js;

            Log("Main Called, it wants its javascript back.");
            //// js.InvokeVoid("console.log", "MainCalled");
            //var spawnNames = js.Invoke<string[]>("bindings.spawnNames");

            //foreach (var spawnName in spawnNames)
            //{
            //    Log(spawnName);
            //    var creep = Game.creeps[spawnName];
            //    if (creep == null)
            //    {
            //        _ = js.Invoke<int>($"Game.spawns.{spawnName}.createCreep", new string[] { "move", "carry", "work" }, spawnName);
            //        continue;
            //    }

            //    var roomRef = $"Game.spawns.{spawnName}.room";

            //    if (js.Invoke<int>($"Game.creeps.{creep.name}.store.energy") == 0)
            //    {
            //        creep.MoveTo(js.Invoke<RoomPosition>($"Game.spawns.{spawnName}.pos"));
            //    }
            //    // if(js.Invoke<int>("Game.creeps.carry.energy") == 0)
            //    //{
            //    js.Invoke<int>($"Game.creeps.{creep.name}.say", "I can C#ly", true);
            //    //}
            //}
            //    CreateHostBuilder(args).Build().Run();
        }
    }
}
