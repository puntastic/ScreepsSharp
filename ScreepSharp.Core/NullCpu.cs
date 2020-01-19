using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepsSharp.Core
{
	public class NullCpu : ICpu
	{
		public float bucket { get; } = 0f;
		public float limit { get; } = 0f;

		public float getUsed() { return 0f; }
	}
}
