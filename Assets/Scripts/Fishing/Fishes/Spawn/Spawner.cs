using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Fishing.Fishes.Spawn
{
	public class Spawner : MonoBehaviour
	{
		[SerializeField] private SpawnConstraints _spawnConstraints;
		[SerializeField] private List<PooledObjectBase> _prefabs;
		[SerializeField] private int _amountInEachPool;
		
		private IEnumerable<Pool> _pools;
		
		private void Start()
		{
			CreatePools();
			ArrangeObjects();
			ActivateObjects();
		}

		private void CreatePools()
		{
			var pools = _prefabs
				.Select(prefab => new Pool(prefab, transform, _amountInEachPool))
				.ToList();

			_pools = pools;
		}

		private void ArrangeObjects()
		{
			foreach (var pool in _pools)
			{
				_spawnConstraints.IncreaseByStep();

				foreach (var inactive in pool.GetInactiveObjects())
					Arrange(inactive);
			}
		}

		private IEnumerable<PooledObjectBase> GetInactiveObjects()
		{
			return _pools.SelectMany(pool => pool.GetInactiveObjects());
		}

		private void Arrange(PooledObjectBase inactive)
		{
			var randomLocalPos = inactive.transform.localPosition;
			randomLocalPos.y = Random.Range(_spawnConstraints.MinY, _spawnConstraints.MaxY);
			inactive.transform.localPosition = randomLocalPos;
		}

		private void ActivateObjects()
		{
			foreach (var inactive in GetInactiveObjects())
				inactive.gameObject.SetActive(true);
		}
	}
}
