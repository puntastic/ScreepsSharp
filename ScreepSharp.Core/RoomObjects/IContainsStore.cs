using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core.RoomObjects
{
	public interface IHasStore //not to be confused with ICanHasStore
	{
		IStore store { get; }
	}
}
