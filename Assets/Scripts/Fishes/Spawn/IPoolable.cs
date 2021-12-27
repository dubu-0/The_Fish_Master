using UnityEngine;

namespace Fishes.Spawn
{
	public interface IPoolable : IStoppable
	{
		public GameObject GameObject { get; }
		
		public void ReInit(Vector3 position);

		public void ReturnToPool();
	}
}
