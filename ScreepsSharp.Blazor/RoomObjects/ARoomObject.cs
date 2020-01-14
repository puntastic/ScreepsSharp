using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public abstract class ARoomObject : IRoomObject
	{
		public string id { get; }
		public bool my => Game.InvokeById<bool>(id, "my");
		public RoomPosition pos => Game.InvokeById<RoomPosition>(id, "pos");

		public IRoom room => Game.rooms[pos.roomName];
		public IEffect effects => throw new NotImplementedException();

		public ARoomObject(string id)
		{
			this.id = id ?? throw new ArgumentNullException(nameof(id));
		}
	}
}
