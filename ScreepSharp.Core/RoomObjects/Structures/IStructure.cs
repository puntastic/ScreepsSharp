using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core.RoomObjects
{
	public interface IStructure : IRoomObject
	{
		StructureType structureType { get; }
		int hits { get;  }
		int hitsMax { get;  }
	}
}
