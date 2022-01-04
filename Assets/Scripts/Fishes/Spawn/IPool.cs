using System.Collections.Generic;

namespace Fishes.Spawn
{
	public interface IPool<out T> where T : PooledObject
	{
		public IEnumerable<T> GetInactiveObjects();
	}
}
