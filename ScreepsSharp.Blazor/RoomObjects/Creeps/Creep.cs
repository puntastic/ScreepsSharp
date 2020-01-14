using ScreepsSharp.Core;
using System.Linq;
using System.Threading.Tasks;
using ScreepsSharp.Core.RoomObjects;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class Creep : ACreepBase, ICreep
	{
		public Creep(string id) : base(id) { }

		public Result Build(IConstructionSite target) { return (Result)Game.InvokeById<int>(id, "_build", target.id); }
		public Result Harvest(ISource source) { return (Result)Game.InvokeById<int>(id, "_harvest", source.id); }
		public Result UpgradeController(IController controller) { return (Result)Game.InvokeById<int>(id, "_upgradeController", controller.id); }
		public Result Transfer(IHasStore target, Resource resource, int amount = 0)
		{
			return (Result)Game.InvokeById<int>(id, "_transfer", ((IStructure)target).id, resource.ToString(), amount);
		}
	}
}