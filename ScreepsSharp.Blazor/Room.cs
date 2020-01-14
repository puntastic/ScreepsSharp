using ScreepSharp.Core;
using ScreepSharp.Core.RoomObjects;
using ScreepsSharp.Blazor.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
	public class Room : IRoom
	{
		public string name { get; }

		private IController _controller = null;
		public IController controller
		{
			get
			{
				if (_controller == null)
				{
					_controller = new Controller(Game.js.Invoke<string>($"{_ref}.controller.id"));
				}

				return _controller;
			}
		}

		public Room(string name)
		{
			this.name = name;
		}

		private string _ref => $"Game.rooms.{name}";

		public IRoomObject[] Find(Find type)
		{
			var ids = Game.js.Invoke<string[]>($"{_ref}.findIds", (int)type);
			var output = new IRoomObject[ids.Length];

			for (int i = 0; i < ids.Length; i++)
			{
				switch (type)
				{
					case ScreepSharp.Core.Find.constructionSites:
						output[i] = new ConstructionSite(ids[i]);
						continue;

					case ScreepSharp.Core.Find.structures:
					case ScreepSharp.Core.Find.myStructures:
						output[i] = FromId(ids[i]);
						continue;

					case ScreepSharp.Core.Find.mySpawns:
						output[i] = new Spawn(ids[i]);
						continue;

					case ScreepSharp.Core.Find.sources:
						output[i] = new Source(ids[i]);
						continue;

					case ScreepSharp.Core.Find.creeps:
					case ScreepSharp.Core.Find.myCreeps:
					case ScreepSharp.Core.Find.hostileCreeps:
						output[i] = new Creep(ids[i]);
						continue;

					default: throw new NotImplementedException(type.ToString()) ;

				}

			}

			return output;
		}

		private IRoomObject FromId(string id)
		{
			StructureType structureType = Game.InvokeById<StructureType>(id, "structureType");
			switch (structureType)
			{
				case StructureType.controller:
					return new Controller(id);
				case StructureType.spawn:
					return new Spawn(id);
			}

			object store = Game.InvokeById<object>(id, "store");
			if(store == null) { return new StructureWithStore(id); }

			return new AStructure(id);
		}
	}
}
