using ScreepsSharp.Core.RoomObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ScreepsSharp.Core
{
	public class NullGame : IGame
	{
		public IJsInterop js { get; } = new NullJsInterop();

		public int time => 0;

		public IReadOnlyDictionary<string, ICreep> creeps { get; } = new Dictionary<string, ICreep>();
		public IReadOnlyDictionary<string, IRoom> rooms { get; } = new Dictionary<string, IRoom>();

		public ICpu cpu { get; } = new NullCpu();

		public event EventHandler tickStarted;

		public T Invoke<T>(string target, params object[] args) { return default; }
		public T InvokeById<T>(string id, string target) { return default; }
		public T InvokeById<T>(string id, string target, params object[] args) { return default; }

		public void OnTickStart() { }
		public void WriteLine(string line) { }

		void IDisposable.Dispose() { }
	}
}
