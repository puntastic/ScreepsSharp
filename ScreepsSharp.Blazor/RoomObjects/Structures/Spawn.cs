using ScreepSharp.Core;
using ScreepSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class Spawn: AStructure, ISpawn
	{
		public Spawn(string id) : base(id) { store = new Store(id); }

		public IStore store { get; } 

		public Result SpawnCreep(Bodypart[] body, string name)
		{
			return Game.InvokeById<Result>(id, "createCreep", body?.Select(o => o.ToString()).ToArray(), name);
		}
	}
}
