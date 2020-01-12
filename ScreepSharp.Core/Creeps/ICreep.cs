using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core
{
    public interface ICreep : ICreepBase
    {
        Bodypart[] body { get; }
    }
}
