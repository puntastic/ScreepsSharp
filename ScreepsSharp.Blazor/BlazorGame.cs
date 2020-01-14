using Mono.WebAssembly.Interop;
using ScreepsSharp.Core;
using ScreepsSharp.Core.RoomObjects;
using ScreepsSharp.Blazor.RoomObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ScreepsSharp.Blazor
{
	public class BlazorGame : IGame
	{
		public IJsInterop js => ScreepsJSRuntime.Current;

		private int _lastUpdate;

		private Dictionary<string, ICreep> _creeps = new Dictionary<string, ICreep>();
		public ReadOnlyDictionary<string, ICreep> creeps { get; }

		private Dictionary<string, IRoom> _rooms = new Dictionary<string, IRoom>();
		public ReadOnlyDictionary<string, IRoom> rooms { get; }

		public int time => js.Invoke<int>("Game.time");

		public event EventHandler tickStarted;
		public void OnTickStart(EventArgs e) { Update(); }

		public BlazorGame()
		{
			rooms = new ReadOnlyDictionary<string, IRoom>(_rooms);
			creeps = new ReadOnlyDictionary<string, ICreep>(_creeps);
		}

		private void Update()
		{
			if (_lastUpdate == time) { return; }
			var creepNames = js.Invoke<string[]>("bindings.creepNames");
			var roomNames = js.Invoke<string[]>("bindings.roomNames");

			//todo: persistence
			_creeps.Clear();
			_rooms.Clear();

			foreach (var name in creepNames)
			{
				string id = js.Invoke<string>($"Game.creeps.{name}.id");
				_creeps.Add(name, new Creep(id));
			}

			foreach (var name in roomNames) { _rooms.Add(name, new Room(name)); }
		}

		public T Invoke<T>(string target, params object[] args)
		{
			//T result = 
			if(typeof(T).IsEnum)
			{
				string result = js.Invoke<string>(target, args);
				return (T)Enum.Parse(typeof(T), result);
			}

			return js.Invoke<T>(target, args);
		}

		public T InvokeById<T>(string id, string target)
		{
			throw new NotImplementedException();
		}

		public T InvokeById<T>(string id, string target, params object[] args)
		{
			throw new NotImplementedException();
		}
	}
}