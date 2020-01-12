global.bindings =
{
	roomNames: function() { return Object.keys(Game.rooms); },
	creepNames: function() { return Object.keys(Game.creeps); },
	spawnNames: function() { return Object.keys(Game.spawns); }
}