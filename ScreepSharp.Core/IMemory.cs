using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Core
{
	public interface IMemory
	{
		object this[string index] { get; set; }
	}
}
