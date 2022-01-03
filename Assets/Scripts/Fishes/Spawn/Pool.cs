using System.Collections.Generic;
using UnityEngine;

namespace Fishes.Spawn
{
	public sealed class Pool<T> : IPool<T> where T : PooledObject
	{
		private readonly List<T> _pooledObjects = new List<T>();

		public Pool(T prefab, Transform container, int amount)
		{
			Prefab = prefab;
			Container = container;
			Amount = amount;

			Fill();
		}

		public T Prefab { get; }
		public Transform Container { get; }
		public int Amount { get; }

		public IEnumerable<T> GetInactiveObjects() => _pooledObjects.FindAll(pooledObject => !pooledObject.gameObject.activeInHierarchy);

		private void Fill()
		{
			for (var i = 0; i < Amount; i++)
				_pooledObjects.Add(CreateObject());
		}

		private T CreateObject()
		{
			var prefabInstance = Object.Instantiate(Prefab, Container);
			prefabInstance.gameObject.SetActive(false);
			return prefabInstance;
		}
	}
}
