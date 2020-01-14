using ScreepSharp.Core;
using ScreepSharp.Core.RoomObjects;
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
			return creep.memory.ContainsKey(theThing) && (bool)creep.memory[theThing];
		}

		public static void ActionHavest(ICreep creep)
		{
			creep.Say("🔄 harvest");
			var sources = creep.room.Find(Find.sources);
			if (creep.Harvest((ISource)sources[0]) != Result.errNotInRange) { return; }

			creep.MoveTo((ISource)sources[0]);
		}

		public static void Upgrader(ICreep creep)
		{
			if (!IsDoingTheThing(creep, "upgrading"))
			{
				ActionHavest(creep);
				return;
			}


			creep.Say("⚡ upgrade");
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

			creep.Say("🚧 build");

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

			creep.Say("⛽ fill");
			var found = creep.room.Find(Find.structures);

			var target = found.FirstOrDefault(o =>
				(o as IHasStore)?
				.store
				.GetFreeCapacity(Resource.energy) > 0
			);

			if (target == null) { return; }

			if (creep.Transfer((IHasStore)target, Resource.energy) != Result.errNotInRange) { return; }
			creep.MoveTo(target);
		}
	}
}
