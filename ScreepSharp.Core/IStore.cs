using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core
{
    public interface IStore
    {
        int this[Resource resource] { get; }

        int GetCapacity(Resource? resource  = null);
        int GetFreeCapacity(Resource? resource = null);
        int GetUsedCapacity(Resource? resource = null);
    }
}
