using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class Spawn: AStructure, ISpawn
	{
		public Spawn(string id, IJsInterop js) : base(id, js) 
		{
			store = new Store($"Game.structures.{id}.store", js);
			//store = new Store(id); 
		}

		public IStore store { get; } 

		public Result SpawnCreep(Bodypart[] body, string name)
		{
			return (Result)_js.InvokeById<int>(id, "spawnCreep", body?.Select(o => o.ToString()).ToArray(), name);
		}
	}
}
