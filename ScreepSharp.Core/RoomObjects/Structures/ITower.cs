using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core.RoomObjects
{
	public interface ITower: IHasStore
	{
		Result Attack(IRoomObject target);
		Result Repair(IRoomObject target);
	}
}
