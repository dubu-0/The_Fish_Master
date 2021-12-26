using Fishes.Spawn;
using UnityEngine;

namespace Fishes.Species
{
	public sealed class SquareFish : Fish, IPoolable
	{
		public void ReInit(Vector3 position) => transform.position = position;
	}
}
