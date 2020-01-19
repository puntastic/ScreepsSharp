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
		public bool my => _js.InvokeById<bool>(id, "my");
		public RoomPosition pos => _js.InvokeById<RoomPosition>(id, "pos");

		public IRoom room => Game.instance.rooms[pos.roomName];
		public IEffect effects => throw new NotImplementedException();

		protected IJsInterop _js { get; }

		public ARoomObject(string id, IJsInterop js)
		{
			this.id = id ?? throw new ArgumentNullException(nameof(id));
			_js = js;
		}
	}
}
