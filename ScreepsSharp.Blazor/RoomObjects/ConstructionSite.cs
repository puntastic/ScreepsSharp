using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor.RoomObjects
{
	public class ConstructionSite :ARoomObject, IConstructionSite
	{
		public ConstructionSite(string id, IJsInterop js) : base(id, js) { }
	}
}
