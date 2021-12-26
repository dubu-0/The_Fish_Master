using Fishes.Spawn;
using UnityEngine;

namespace Fishes.Species
{
	public sealed class CircleFish : Fish, IPoolable
	{
		public void ReInit(Vector3 position) => transform.position = position;
	}
}
