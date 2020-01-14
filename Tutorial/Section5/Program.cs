using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.JSInterop;
using ScreepSharp.Core;
using ScreepSharp.Core.RoomObjects;
using ScreepsSharp.Blazor;
using System.Linq;


namespace ScreepsSharp.Tutorial.Section5
{

	public class Program
	{
		private static bool _initialized = false;
		private static void Log(string s) { Game.js.InvokeVoid("console.log", s); }

		public static void TickRoom(IRoom room)
		{
			if (!(room.controller?.my ?? false)) { return; }
			Log(room.name);
		///	var towers = room.Find(Find.myStructures)
		///		.Where(o => (o as IStructure)?.structureType == StructureType.tower)
		///		.Cast<ITower>()
		///		.ToArray();
		///		
		///	var damaged = room.Find(Find.myStructures)
		///		.Where(o => (o as IStructure)?.hits < (o as IStructure).hitsMax)
		///		.Cast<IStructure>()
		///		.ToArray();
		///		
		///	var hostiles = room.Find(Find.hostileCreeps)
		///		.Cast<ICreepBase>()
		///		.ToArray();
		///		
			var spawns = room.Find(Find.mySpawns)
				.Cast<ISpawn>()
				.ToArray();

			///foreach (var tower in towers)
			///{
			///	if (hostiles.Length > 0)
			///	{
			///		tower.Attack(hostiles[0]);
			///		break; //continue; // NCP's need not apply. Only one tower for you!
			///	}
			///
			///	if (damaged.Length > 0) { tower.Repair(damaged[0]); }
			///
			///	break; //continue;
			///}
			ICreep creep;
			var parts = new[] { Bodypart.move, Bodypart.move, Bodypart.carry, Bodypart.work };
			if (TryGetCreepOrSpawn(room.name + "harvester", out creep, parts, spawns.FirstOrDefault()))
			{
				Roles.Harvester(creep);
			}

			if (TryGetCreepOrSpawn(room.name + "upgrader", out creep, parts, spawns.FirstOrDefault()))
			{
				Roles.Upgrader(creep);
			}

			if (TryGetCreepOrSpawn(room.name + "builder", out creep, parts, spawns.FirstOrDefault()))
			{
				Roles.Builder(creep);
			}
		}

		public static bool TryGetCreepOrSpawn(string name, out ICreep creep, Bodypart[] parts, ISpawn spawn)
		{
			if (Game.creeps.TryGetValue(name, out creep)) { return true; }

			Log(spawn?.SpawnCreep(parts, name).ToString() ?? "-42");

			return false;
		}

		public static void Main(string[] args)
		{
			if (!_initialized)
			{
				Game.Init(new BlazorGame());
				_initialized = true;
			}

			Game.OnTickStart();
			Log("Main Called");


			foreach (var room in Game.rooms.Values)
			{
				TickRoom(room);
			}

		}
	}
}
