using ScreepSharp.Core;
using ScreepSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public abstract class ACreepBase : ARoomObject, ICreepBase
	{
		public IStore store { get; }
		public string name => Game.InvokeById<string>(id, "name");
		public int hits => Game.InvokeById<int>(id, "hits");
		public int hitsMax => Game.InvokeById<int>(id, "hitsMax");
		public Dictionary<string, object> memory { get; } = new Dictionary<string, object>();
		public Bodypart[] body => throw new System.NotImplementedException();

		public ACreepBase(string id) : base(id) { store = new Store(id); }


		public int MoveTo(RoomPosition target, int reusePath, bool serializeMemory, bool noPathFinding)
		{
			return Game.InvokeById<int>(this.id, "moveTo", target);
		}

		public int Say(string message, bool publiclyVisible = false)
		{
			return Game.InvokeById<int>(id, "say", message, publiclyVisible);
		}

		Result ICreepBase.MoveTo(RoomPosition target, int reusePath, bool serializeMemory, bool noPathFinding)
		{
			throw new NotImplementedException();
		}

		public Result MoveTo(IRoomObject target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false)
		{
			throw new NotImplementedException();
		}

		Result ICreepBase.Say(string message, bool publiclyVisible)
		{
			throw new NotImplementedException();
		}
	}
}
