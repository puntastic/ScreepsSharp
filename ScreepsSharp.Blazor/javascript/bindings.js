//most of these are tempoerary while I build up the framework



global.invokeByObjId = function (id, func, args)
{
	if (!id) { throw new Error("No id parameter"); };

	let obj = Game.getObjectById(id);
	if (!func) { return obj; }

	if (!obj) { throw new Error(`No object found with ${id} found.`); }
	//if (obj[func] === undefined) { throw new Error(`No target ${func} found on ${obj}`); }

	if (typeof obj[func] !== "function") { return obj[func]; }
	return obj[func].apply(obj, args);
}

global.setMemoryByObjId = function (id, key, val)
{
	Game.getObjectById(id).memory[key] = val;
}

global.getMemoryByObjId = function (id, key)
{
	return Game.getObjectById(id).memory[key];
}


Room.prototype.findIds = function (findType, opts)
{
	return _.map(this.find(findType, opts), val => val.id);
}

Creep.prototype._moveTo = function (id) { return this.moveTo(Game.getObjectById(id)); }
Creep.prototype._harvest = function (id) { return this.harvest(Game.getObjectById(id)); }
Creep.prototype._build = function (id) { return this.build(Game.getObjectById(id)); }
Creep.prototype._upgradeController = function (id) { return this.upgradeController(Game.getObjectById(id)); }
Creep.prototype._transfer = function (id, resource, amount) { return this.transfer(Game.getObjectById(id), resource, amount); }

StructureTower.prototype._repair = function (id) { return this.repair(Game.getObjectById(id)); }
StructureTower.prototype._attack = function (id) { return this.attack(Game.getObjectById(id)); }


global.setValue = function(path, key, value)
{
	let obj = navigatePath(path);
	if (!obj) { return; }

	obj[key] = value;
}
global.getValue = function(path, key)
{
	let obj = navigatePath(path);
	if (!obj) { return null; }

	return obj[key];
}

global.getKeys = function(path)
{
	let obj = navigatePath(path);
	if (obj == null) { return null; }

	return Object.keys(obj);
}

function navigatePath(path)
{
	let result = global;
	let segments = path.split('.');
	for (let i = 0; i < segments.length; i++)
	{
		let segment = segments[i];
		lastSegmentValue = result;

		if(!(segment in result)) { return null; }

		result = result[segment];
	}

	return result;
}