using Newtonsoft.Json;
using ScreepSharp.Core;
using System.Linq;
using System.Threading.Tasks;
using ScreepSharp.Core.RoomObjects;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class Creep : ACreepBase, ICreep
	{
		public Creep(string id) : base(id) { }

		public Result Build(IConstructionSite target) { return Game.InvokeById<Result>(id, "_build", target.id); }
		public Result Harvest(ISource source) { return Game.InvokeById<Result>(id, "_harvest", source.id); }
		public Result UpgradeController(IController controller) { return Game.InvokeById<Result>(id, "_upgradeController", controller.id); }
		public Result Transfer(IHasStore target, Resource resource, int amount = 0)
		{
			return Game.InvokeById<Result>(id, "_transfer", ((IStructure)target).id, resource.ToString(), amount);
		}
	}
}