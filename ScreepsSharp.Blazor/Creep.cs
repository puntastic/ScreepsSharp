using Newtonsoft.Json;
using ScreepSharp.Core;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
    public class Creep : ICreep
    {
        public Bodypart[] body => throw new System.NotImplementedException();
        public string id => throw new System.NotImplementedException();
        public IRoom room => throw new System.NotImplementedException();
        
        public IEffect effects => throw new System.NotImplementedException();
        
        public RoomPosition pos => Game.js.JsonConvertInvoke<RoomPosition>($"{_ref}.pos");
        public string name { get; private set; }
        
        private string _ref => $"Game.creeps.{name}";

        public Creep(string name) => this.name = name;

        public int MoveTo(RoomPosition target, int reusePath, bool serializeMemory, bool noPathFinding)
        {
            return Game.js.Invoke<int>($"{_ref}", target);
        }
    }
}