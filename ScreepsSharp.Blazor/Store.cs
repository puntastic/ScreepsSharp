using ScreepSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
    public class Store : IStore
    {
        private readonly string _id;
        
        public int this[Resource resource] { get { return GetFreeCapacity(resource); } }
        public Store(string id) { _id = id; }      

        public int GetCapacity(Resource? resource) { return Game.InvokeById<int>(_id, "getCapacity", resource?.ToString()); }
        public int GetFreeCapacity(Resource? resource) { return Game.InvokeById<int>(_id, "getFreeCapacity", resource?.ToString()); }
        public int GetUsedCapacity(Resource? resource) { return Game.InvokeById<int>(_id, "getUsedCapacity", resource?.ToString()); }
    }
}
