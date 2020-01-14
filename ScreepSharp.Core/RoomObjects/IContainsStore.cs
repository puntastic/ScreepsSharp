using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core.RoomObjects
{
	public interface IHasStore //not to be confused with ICanHasStore
	{
		IStore store { get; }
	}
}
