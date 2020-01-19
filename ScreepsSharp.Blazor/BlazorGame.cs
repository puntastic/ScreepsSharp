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
		public IJsInterop js { get; }

		private Dictionary<string, ICreep> _creeps = new Dictionary<string, ICreep>();
		public IReadOnlyDictionary<string, ICreep> creeps { get { return _creeps; } }

		private Dictionary<string, IRoom> _rooms = new Dictionary<string, IRoom>();
		public IReadOnlyDictionary<string, IRoom> rooms { get { return _rooms; } }

		public int time { get; private set; } = 0;
		public ICpu cpu { get; }

		public event EventHandler tickStarted;
		private int _lastUpdate = 0;

		public BlazorGame()
		{
			js = BlazorJSRuntime.Current;
			cpu = new Cpu(js);
		}

		private void Update()
		{
			time = js.Invoke<int>("Game.time");
			if (_lastUpdate == time) { return; }
			_lastUpdate = time;

			//XXXX: make sure you update rooms first so creeps can reference them
			_rooms = GetUpdated("Game.rooms", _rooms, (n, j) => new Room(n, j));
			_creeps = GetUpdated("Game.creeps", _creeps, (n, j) =>
			{
				string id = js.Invoke<string>($"Game.creeps.{n}.id");
				return new Creep(id, j);
			});
		}

		// todo: profile I expect using passing in a function to be brutally slow. Regardless this is only called at
		// the beggining of the tick
		Dictionary<string, T> GetUpdated<T>(string path, Dictionary<string, T> collection, Func<string, IJsInterop, T> create)
		{
			var names = js.GetKeys(path);
			var updated = new Dictionary<string, T>();

			for (int i = 0; i < names.Length; i++)
			{
				T current = collection.ContainsKey(names[i]) ? collection[names[i]] : create(names[i], js);
				updated.Add(names[i], current);
			}

			return updated;
		}

		public void WriteLine(string line) { js.WriteLine(line); }

		public void OnTickStart()
		{
			Update();
			tickStarted?.Invoke(null, null);
		}

		#region IDisposable Support
		private bool _isDisposed = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!_isDisposed)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				_isDisposed = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~BlazorGame()
		// {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}