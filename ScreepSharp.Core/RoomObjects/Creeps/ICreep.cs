using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core.RoomObjects
{
    public interface ICreep : ICreepBase
    {
        int hits { get; }
        int hitsMax { get; }
        Bodypart[] body { get; }

        Result UpgradeController(IController controller);
        Result Harvest(ISource source);
        Result Build(IConstructionSite target);
        Result Transfer(IHasStore target, Resource resource, int amount = 0);
    }
}
