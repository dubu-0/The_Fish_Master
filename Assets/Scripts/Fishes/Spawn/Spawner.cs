using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace Fishes.Spawn
{
	public sealed class Spawner : MonoBehaviour
	{
		[SerializeField] private List<PooledObject> prefabs;
		[SerializeField] private int amountInEachPool;
		[SerializeField] private SpawnConstraints spawnConstraints;

		private readonly List<IPool<PooledObject>> _pools = new List<IPool<PooledObject>>();

		private void Start()
		{
			CreatePools();
			Spread();
			ActivateObjects();
		}

		private void CreatePools()
		{
			foreach (var prefab in prefabs)
				_pools.Add(new Pool<PooledObject>(prefab, transform, amountInEachPool));
		}

		private void Place([NotNull] PooledObject inactive)
		{
			var randomLocalPos = inactive.transform.localPosition;
			randomLocalPos.y = Random.Range(spawnConstraints.MinY, spawnConstraints.MaxY);
			inactive.transform.localPosition = randomLocalPos;
		}

		private void Spread()
		{
			foreach (var pool in _pools)
			{
				spawnConstraints.Increase();

				foreach (var inactive in pool.GetInactiveObjects())
					Place(inactive);
			}
		}

		private void ActivateObjects()
		{
			foreach (var inactive in GetAllInactiveObjects())
				inactive.gameObject.SetActive(true);
		}

		private IEnumerable<PooledObject> GetAllInactiveObjects() => _pools.SelectMany(pool => pool.GetInactiveObjects());
	}
}
