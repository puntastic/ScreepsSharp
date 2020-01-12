using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.JSInterop;
using System.Linq;

namespace Screeps.Blazor.PoC
{
    public class Program
    {
        private static void Log(string s) { ScreepsJSRuntime.Current.InvokeVoid("console.log", s); }
        public static void Main(string[] args)
        {
            var js = ScreepsJSRuntime.Current;
            Log("Main Called");
           // js.InvokeVoid("console.log", "MainCalled");
            var spawnNames = js.Invoke<string[]>("bindings.spawnNames");
            var creepNames = js.Invoke<string[]>("bindings.creepNames");

            foreach(var currentSpawn in spawnNames)
            {
                Log(currentSpawn);
                var creepName = creepNames.FirstOrDefault(o => o == currentSpawn);
                if(creepName == null)
                {
                    var r = js.Invoke<int>($"Game.spawns.{currentSpawn}.createCreep", new string[] { "move", "carry", "work" }, currentSpawn);
                    Log(r.ToString());
                    continue;
                }


                // if(js.Invoke<int>("Game.creeps.carry.energy") == 0)
                //{
                js.Invoke<int>($"Game.creeps.{creepName}.say", "I can C#ly", true);
                //}
            }
            //    CreateHostBuilder(args).Build().Run();
        }
    }
}
