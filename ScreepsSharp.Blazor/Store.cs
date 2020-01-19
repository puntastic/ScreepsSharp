using ScreepsSharp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
    public class Store : IStore
    {
        public int this[Resource resource] { get { return GetUsedCapacity(resource); } }

        private readonly string _path;
        protected IJsInterop _js { get; }

        public Store(string path, IJsInterop js) 
        {
            _path = path;
            _js = js;
        }      

        public int GetCapacity(Resource? resource) { return _js.Invoke<int>($"{_path}.getCapacity", resource?.ToString()); }
        public int GetFreeCapacity(Resource? resource) { return _js.Invoke<int>($"{_path}.getFreeCapacity", resource?.ToString()); }
        public int GetUsedCapacity(Resource? resource) { return _js.Invoke<int>($"{_path}.getUsedCapacity", resource?.ToString()); }
    }
}
