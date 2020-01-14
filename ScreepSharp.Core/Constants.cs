using System;
using System.Collections.Generic;
using System.Text;

namespace ScreepSharp.Core
{
	// torn on how much should be hardcoded and how much should be dynamically loaded
	// for now i'll try the below and we how I like how it turns out.
	//
	// XXXX: these enums need to be named as they appear in string form    
	public enum Bodypart { move, work, carry, attack, ranged_attack, tough, heal, claim, unkown }
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
		invaderCore,
		unknown
	}
	public enum Resource
	{
		energy,
		power,
		U,
		L,
		K,
		G,
		Z,
		O,
		H,
		X,
		OH,
		ZK,
		UL,
		UH,
		UO,
		KH,
		KO,
		LH,
		LO,
		ZH,
		ZO,
		GH,
		GO,
		UH2O,
		UHO2,
		KH2O,
		KHO2,
		LH2O,
		LHO2,
		ZH2O,
		ZHO2,
		GH2O,
		GHO2,
		XUH2O,
		XUHO2,
		XKH2O,
		XKHO2,
		XLH2O,
		XLHO2,
		XZH2O,
		ZXHO2,
		XGH2O,
		XGHO2,
		unknown,
	}

	public enum Result
	{
		ok = 0,
		errNotOwner = -1,
		errNoPath = -2,
		errNameExists = -3,
		errBusy = -4,
		errNotFound = -5,
		//errNotEnoughEnergy = -6, //decprecated?
		//errNotEnoughExtensions = -6, //deprecated?
		errNotEnoughResources = -6,
		errInvalidTarget = -7,
		errFull = -8,
		errNotInRange = -9,
		errInvalidArgs = -10,
		errTired = -11,
		errNoBodyPart = -12,
		errRclNotEnough = -14,
		errGclNotEnough = -15,
	}

	public enum Find
	{
		exitTop = 1,
		exitRight = 3,
		exitBottom = 5,
		exitLeft = 7,
		exit = 10,
		creeps = 101,
		myCreeps = 102,
		hostileCreeps = 103,
		sourcesActive = 104,
		sources = 105,
		droppedResources = 106,
		structures = 107,
		myStructures = 108,
		flags = 110,
		constructionSites = 111,
		mySpawns = 112,
		hostileSpawns = 113,
		myConstructionSites = 114,
		hostileConstructionSites = 115,
		minerals = 116,
		nukes = 117,
		tombstones = 118,
		powerCreeps = 119,
		myPowerCreeps = 120,
		hostilePowerCreeps = 121,
		deposits = 112,
		ruins = 123
	}
}
