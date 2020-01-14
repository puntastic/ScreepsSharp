using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
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
					case ScreepsSharp.Core.Find.constructionSites:
						output[i] = new ConstructionSite(ids[i]);
						continue;

					case ScreepsSharp.Core.Find.structures:
					case ScreepsSharp.Core.Find.myStructures:
						output[i] = FromId(ids[i]);
						continue;

					case ScreepsSharp.Core.Find.mySpawns:
						output[i] = new Spawn(ids[i]);
						continue;

					case ScreepsSharp.Core.Find.sources:
						output[i] = new Source(ids[i]);
						continue;

					case ScreepsSharp.Core.Find.creeps:
					case ScreepsSharp.Core.Find.myCreeps:
					case ScreepsSharp.Core.Find.hostileCreeps:
						output[i] = new Creep(ids[i]);
						continue;

					default: throw new NotImplementedException(type.ToString());

				}

			}

			return output;
		}

		private IRoomObject FromId(string id)
		{
			if (!Enum.TryParse(Game.InvokeById<string>(id, "structureType"), out StructureType structureType))
			{
				structureType = StructureType.unknown;
			}

			switch (structureType)
			{
				case StructureType.controller: return new Controller(id);
				case StructureType.spawn: return new Spawn(id);
				case StructureType.extension: return new StructureWithStore(id);
				case StructureType.tower: return new Tower(id);

			}

			return new AStructure(id);
		}
	}
}
