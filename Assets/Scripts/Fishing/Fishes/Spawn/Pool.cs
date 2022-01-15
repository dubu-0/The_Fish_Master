using System.Collections.Generic;
using UnityEngine;

namespace Fishing.Fishes.Spawn
{
	public sealed class Pool
	{
		private readonly List<PooledObjectBase> _pooledObjects = new List<PooledObjectBase>();
		
		private readonly PooledObjectBase _prefab;
		private readonly Transform _container;
		private readonly int _amount;
		
		public Pool(PooledObjectBase prefab, Transform container, int amount)
		{
			_prefab = prefab;
			_container = container;
			_amount = amount;

			Fill();
		}

		public IEnumerable<PooledObjectBase> GetInactiveObjects() => _pooledObjects.FindAll(pooledObject => !pooledObject.gameObject.activeInHierarchy);

		private void Fill()
		{
			for (var i = 0; i < _amount; i++)
				_pooledObjects.Add(CreateObject());
		}

		private PooledObjectBase CreateObject()
		{
			var prefabInstance = Object.Instantiate(_prefab, _container);
			prefabInstance.gameObject.SetActive(false);
			return prefabInstance;
		}
	}
}
