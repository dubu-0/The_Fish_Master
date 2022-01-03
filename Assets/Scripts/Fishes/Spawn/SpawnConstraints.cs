using System;
using UnityEngine;

namespace Fishes.Spawn
{
	[Serializable]
	public struct SpawnConstraints
	{
		public SpawnConstraints(float minY, float maxY, float step)
		{
			MinY = minY;
			MaxY = maxY;
			Step = step;
		}

		[field: SerializeField] public float MinY { get; private set; }
		[field: SerializeField] public float MaxY { get; private set; }
		[field: SerializeField] public float Step { get; private set; }

		public void Increase()
		{
			MinY += Step;
			MaxY += Step;
		}
	}
}
