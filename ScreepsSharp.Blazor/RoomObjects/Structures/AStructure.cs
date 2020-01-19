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
		public AStructure(string id, IJsInterop js) : base(id, js) { }

		public virtual StructureType structureType
		{
			get
			{
				if (!Enum.TryParse(_js.InvokeById<string>(id, "structureType"), out StructureType structureType))
				{
					return StructureType.unknown;
				}

				return structureType;
			}
		}

		public int hits => _js.InvokeById<int>(id, "hits");
		public int hitsMax => _js.InvokeById<int>(id, "hitsMax");

	}
}
