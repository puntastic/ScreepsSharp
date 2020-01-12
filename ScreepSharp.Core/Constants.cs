using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core
{
    // torn on how much should be hardcoded and how much should be dynamically loaded
    // for now i'll try the below and we how I like how it turns out.
    //
    // XXXX: these enums need to be named as they appear in string form    
    public enum Bodypart { move, work, carry, attack, ranged_attack, tough, heal, claim }
    public enum StructureType 
    { 
        spawn,
        extension,
        road,
        constructedWall,
        rampart,
        keepeprLair,
        portal,
        controller,
        link,
        storage,
        tower,
        observer,
        powerBank,
        powerSpawn,
        extractor,
        lab,
        terminal,
        container,
        nuker,
        factory,
        invaderCore 
    }
}
