using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System.Linq;

using System;
namespace ScreepsSharp.Tutorial.Section5
{
	// Don't really want to teach bad habits in the tutorial code
	// But this keeps it close to the original tutorial
	public static class Roles
	{
		private static bool IsDoingTheThing(ICreep creep, string theThing)
		{
			if (creep.store[Resource.energy] == 0) { creep.memory[theThing] = false; }
			if (creep.store.GetFreeCapacity() == 0) { creep.memory[theThing] = true; }

			//todo: this will need to be updated when I write a proper memory object
			return (bool?)creep.memory[theThing] ?? false;
		}

		public static void ActionHavest(ICreep creep)
		{
			creep.Say("🔄 harvest", true);

			var sources = creep.room.Find(Find.sources);
			var result = creep.Harvest((ISource)sources[0]);
			
			switch (result)
			{
				case Result.errNotInRange:
					creep.MoveTo(sources[0]); 
					break;
				case Result.ok:	break;
			}
		}

		public static void Upgrader(ICreep creep)
		{
			if (!IsDoingTheThing(creep, "upgrading"))
			{
				ActionHavest(creep);
				return;
			}

			creep.Say("⚡ upgrade", true);

			if (creep.UpgradeController(creep.room.controller) != Result.errNotInRange) { return; }
			creep.MoveTo(creep.room.controller);
		}

		public static void Builder(ICreep creep)
		{
			if (!IsDoingTheThing(creep, "building"))
			{
				ActionHavest(creep);
				return;
			}

			creep.Say("🚧 build", true);

			var targets = creep.room.Find(Find.constructionSites);
			if (targets.Length == 0) { return; }

			if (creep.Build((IConstructionSite)targets[0]) != Result.errNotInRange) { return; }
			creep.MoveTo(targets[0]);
		}

		public static void Harvester(ICreep creep)
		{
			if (!IsDoingTheThing(creep, "filling"))
			{
				ActionHavest(creep);
				return;
			}

			creep.Say("⛽ fill", true);

			var found = creep.room.Find(Find.structures);
			var target = found.FirstOrDefault(o=>
			{
				switch((o as IStructure)?.structureType)
				{
					case StructureType.spawn:
					case StructureType.extension:
					case StructureType.tower:
						return ((o as IHasStore)?.store.GetFreeCapacity() ?? 0) > 0;

					default: return false;
				}
			}
			);

			if (target == null) { return; }

			if (creep.Transfer((IHasStore)target, Resource.energy) != Result.errNotInRange) { return; }
			creep.MoveTo(target);
		}
	}
}
