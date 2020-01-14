using ScreepSharp.Core;
using ScreepSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public /*abstract*/ class AStructure : ARoomObject, IStructure
	{
		public AStructure(string id) : base(id) { }

		public virtual StructureType structureType => Game.InvokeById<StructureType>(id, "structureType");

		public int hits => Game.InvokeById<int>(id, "hits");
		public int hitsMax => Game.InvokeById<int>(id, "hitsMax");

	}
}
