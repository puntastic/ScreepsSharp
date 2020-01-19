using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public abstract class ACreepBase : ARoomObject, ICreepBase
	{
		public IStore store { get; }

		public string name => _js.InvokeById<string>(id, "name");
		public int hits => _js.InvokeById<int>(id, "hits");
		public int hitsMax => _js.InvokeById<int>(id, "hitsMax");
		public Bodypart[] body => throw new NotImplementedException();
		public IMemory memory { get; }

		public ACreepBase(string id, IJsInterop js) : base(id, js)
		{
			store = new Store($"Game.creeps.{name}.store", js);
			memory = new Memory($"Memory.creeps.{name}", js);
		}

		public Result MoveTo(IRoomObject target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false)
		{
			return (Result)_js.InvokeById<int>(id, "_moveTo", target.id);
		}

		public Result MoveTo(RoomPosition target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false)
		{
			return (Result)_js.InvokeById<int>(this.id, "moveTo", target);
		}

		Result ICreepBase.Say(string message, bool publiclyVisible)
		{
			return (Result)_js.InvokeById<int>(id, "say", message, publiclyVisible);
		}


	}
}
