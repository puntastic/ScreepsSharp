using ScreepsSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
    public class Store : IStore
    {
        private readonly string _path;
        
        public int this[Resource resource] { get { return GetUsedCapacity(resource); } }
        public Store(string path) { _path = path; }      

        public int GetCapacity(Resource? resource) { return Game.Invoke<int>($"{_path}.getCapacity", resource?.ToString()); }
        public int GetFreeCapacity(Resource? resource) { return Game.Invoke<int>($"{_path}.getFreeCapacity", resource?.ToString()); }
        public int GetUsedCapacity(Resource? resource) { return Game.Invoke<int>($"{_path}.getUsedCapacity", resource?.ToString()); }
    }
}
