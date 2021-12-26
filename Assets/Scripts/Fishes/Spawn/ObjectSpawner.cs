using System.Collections.Generic;
using UnityEngine;

namespace Fishes.Spawn
{
	public sealed class ObjectSpawner : MonoBehaviour
	{
		[SerializeField] private List<ObjectPool> objectPools;

		private void Update()
		{
			for (var i = 0; i < objectPools.Count; i++)
			{
				var randomY = Random.Range(objectPools[i].BottomLevel, objectPools[i].TopLevel);
				var randomSpawnPosition = new Vector2(0f, randomY);
				objectPools[i].ReInitObject(randomSpawnPosition);
			}
		}

		private void OnEnable()
		{
			for (var i = 0; i < objectPools.Count; i++)
				objectPools[i].Init(transform);
		}
	}
}
