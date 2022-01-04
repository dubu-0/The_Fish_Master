using System.Collections.Generic;
using UnityEngine;

namespace Fishes.Spawn
{
	public sealed class Pool<T> : IPool<T> where T : PooledObject
	{
		private readonly List<T> _pooledObjects = new List<T>();
		
		private readonly T _prefab;
		private readonly Transform _container;
		private readonly int _amount;
		
		public Pool(T prefab, Transform container, int amount)
		{
			_prefab = prefab;
			_container = container;
			_amount = amount;

			Fill();
		}

		public IEnumerable<T> GetInactiveObjects() => _pooledObjects.FindAll(pooledObject => !pooledObject.gameObject.activeInHierarchy);

		private void Fill()
		{
			for (var i = 0; i < _amount; i++)
				_pooledObjects.Add(CreateObject());
		}

		private T CreateObject()
		{
			var prefabInstance = Object.Instantiate(_prefab, _container);
			prefabInstance.gameObject.SetActive(false);
			return prefabInstance;
		}
	}
}
