using System.Collections.Generic;
using UnityEngine;

namespace Fishes.Spawn
{
	public interface IPool<out T>
	{
		public T Prefab { get; }
		public Transform Container { get; }
		public int Amount { get; }

		public IEnumerable<T> GetInactiveObjects();
	}
}
