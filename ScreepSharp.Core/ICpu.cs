﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Core
{
	public interface ICpu
	{
		float getUsed();
		float bucket { get; }
		float limit { get; }
	}
}
