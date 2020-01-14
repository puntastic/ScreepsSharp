using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public /*abstract*/ class AStructure : ARoomObject, IStructure
	{
		public AStructure(string id) : base(id) { }

		public virtual StructureType structureType
		{
			get
			{
				if (!Enum.TryParse(Game.InvokeById<string>(id, "structureType"), out StructureType structureType))
				{
					return StructureType.unknown;
				}

				return structureType;
			}
		}

		public int hits => Game.InvokeById<int>(id, "hits");
		public int hitsMax => Game.InvokeById<int>(id, "hitsMax");

	}
}
