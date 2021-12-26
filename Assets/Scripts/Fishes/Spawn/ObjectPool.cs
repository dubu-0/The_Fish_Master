using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Fishes.Spawn
{
	[CreateAssetMenu(menuName = "Create ObjectPool", fileName = "ObjectPool", order = 0)]
	public sealed class ObjectPool : ScriptableObject
	{
		[SerializeField] private GameObject objectToPool;
		[SerializeField] private int amount = 15;

		private static readonly Vector3 CommonOffset = new Vector3(0f, -10f, 0f);
		private readonly Queue<GameObject> _pool = new Queue<GameObject>();

		[field: SerializeField] public int TopLevel { get; [UsedImplicitly] private set; }
		[field: SerializeField] public int BottomLevel { get; [UsedImplicitly] private set; }

		public void Init(Transform parentForObjects)
		{
			for (var i = 0; i < amount; i++)
			{
				var objectInstance = Instantiate(objectToPool, parentForObjects, true);
				objectInstance.SetActive(false);
				_pool.Enqueue(objectInstance);
			}
		}

		public void ReInitObject(Vector3 position)
		{
			if (TryDequeuePooledObject(out var pooled))
				pooled!.GetComponent<IPoolable>()?.ReInit(position + CommonOffset);
		}

		public void ReturnObjectToPool([NotNull] GameObject objectToReturn)
		{
			objectToReturn.SetActive(false);
			_pool.Enqueue(objectToReturn);
		}

		private bool TryDequeuePooledObject([CanBeNull] out GameObject pooled)
		{
			if (_pool.Count > 0)
			{
				pooled = _pool.Dequeue();
				pooled.SetActive(true);
			}
			else
			{
				pooled = null;
			}

			return pooled;
		}
	}
}
