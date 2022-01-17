using System;
using UnityEngine;

namespace Fishing.Fishes.Spawn
{
	[Serializable]
	public struct SpawnConstraints
	{
		[field: SerializeField] public float MinY { get; private set; }
		[field: SerializeField] public float MaxY { get; private set; }
		[field: SerializeField] public float Step { get; private set; }

		public void IncreaseByStep()
		{
			MinY += Step;
			MaxY += Step;
		}
	}
}
