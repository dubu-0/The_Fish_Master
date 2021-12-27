using UnityEngine;

namespace Fishes.Spawn
{
	public interface IPoolable
	{
		public void ReInit(Vector3 position);
		public void SetObjectPool(ObjectPool pool);
	}
}
