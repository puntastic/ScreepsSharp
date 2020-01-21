# Design Philosophy
The core goal of this project is to provide a wrapper for the screeps javascript api. To this end the resulting api should look as close the [api documentation](https://docs.screeps.com/api/) as is reasonable.

Of couse since I am writing this project first and foremost for myself I am bringing my own biases so ymmv as to what reasonable is.

Finally, a good deal of this codebase is prototype or stopgap and is therefore subject to change without warning.

## Exceptions
While it is unreasonable, ideally no exceptions would be thrown by this framework at all. Wherever possible failure cases should be as transparent as possible without resorting to throwing exceptions.

Eg. "Set()" functions becoming "TrySet()" or perhaps even "CallSet()" with a Result value.

# Changes & Additions
# Persistance
*All* objects should be made safe to keep references to and reuse across multiple ticks. Trust me, you do not want to make the .net garbage collector angry now that it has been turned up as agressive as it can go.

A new error type "errNotVisible", null object patterns & nullable value types are used to facilitate this (exact implementation pending).

# Defunct methods
No currently defunct methods/properties are planned to be supported. Due to github history & branching features anything that becomes obsolete within the js api will be removed, more or less, without prior warning.

Once this project stable development will be conducted on its own branch. Regardless, sync with care.

## Enum types & naming
Enum types are used in many places. If the js api is string valued the C# enum be named identically to their value. This is for ease of .toString() conversions.  Numeric don't follow this enums are named similar to they key instead.

For example:
* "RESOURCE_ENERGY = 'energy' " for screeps corresponds to "Resource.energy" in C#
* "FIND_EXIT_TOP = 1" corresponds to "Find.exitTop" in c#

Finally all enums should have an additional 'unknown' value to allow for lead in time with js api changes. 

## Function naming & overloading
All functions should be named and operate similarly to their js counterparts where possible. They should however take advantage of overloads, optional methods & templates. 

For example the [moveTo()](https://docs.screeps.com/api/#Creep.moveTo) of the js api can be represented as two methods:
> Result MoveTo(RoomPosition target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false);
> Result MoveTo(IRoomObject target, int reusePath = 5, bool serializeMemory = true, bool noPathFinding = false);

The most common departure from this approach is where Try[functionName] () or similar allows for more complete feedback to user code without resorting to exceptions.

Some functions (Room.Find comes to mind) will require thought as to if this approach is reasonble; They *may* have too many possible return types and use cases for type-constrained C#.

## Inheretence
Screeps makes extensive use of inheritence. However C# types are not as... flexible as javascript types. This means that many elements (such as the ['store'](https://docs.screeps.com/api/#Store) property) need to be split off into their own interfaces or pushed down to lower levels and defaulted to null.

I have not made up my mind on the specifics.

## Interfaces
All aspects of the screeps api needs to be accesible via interfaces. A users' code should talk to an IGame to get a collection of ICreeps etc. Not only will this make mocking and testing easier but it will also allow for the engine to swapped out a bit easier if need be.

## Singletons
I avoid singletons personally but don't feel that they are an antipattern either; They're a tool to be used. 

Regardless any singleton should be available via a ".instance" property rather than directly invoked. eg. "Game.creeps" becomes a "Game.instance.creeps" IGame typed property.
