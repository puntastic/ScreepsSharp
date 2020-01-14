using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core.RoomObjects
{
	public interface ISource : IRoomObject
	{
		int energy { get; }
		int energyCapacity { get; }
		int ticksToRegeneration { get; }
	}
}
