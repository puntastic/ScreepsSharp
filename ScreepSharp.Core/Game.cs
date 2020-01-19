using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace ScreepsSharp.Core
{
	// can't say I like singletons but if you can Game.creeps in screeps
	// I want to damn well be able to here
	public static class Game
	{
		// setting the instance to a null object by default for testing or whathaveyou
		public static IGame instance { get; private set; } = new NullGame();
		public static IJsInterop js { get { return instance.js; } }
		public static bool isReady { get; private set; } = false;

		public static void Initialize(IGame game) 
		{
			instance = game;
			isReady = true;
		}
	}
}
