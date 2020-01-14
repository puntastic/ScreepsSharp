using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class StructureWithStore : AStructure, IHasStore
	{
		public StructureWithStore(string id) : base(id) 
		{
			store = new Store($"Game.structures.{id}.store");
		}

		public IStore store { get; }
	}
}
