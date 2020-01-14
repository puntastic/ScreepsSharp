using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core.RoomObjects
{
	public interface ISpawn : IStructure, IHasStore
	{
		Result SpawnCreep(Bodypart[] body, string name);
	}
}
