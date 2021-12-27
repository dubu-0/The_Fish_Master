using System.Collections.Generic;
using Fishes;
using JetBrains.Annotations;
using UnityEngine;

namespace FishingGear.FishingLine
{
	[RequireComponent(typeof(CircleCollider2D))]
	public sealed class Hook : MonoBehaviour
	{
		private readonly List<Fish> _caughtFishes = new List<Fish>();
		private CircleCollider2D _circleCollider2D;

		public IEnumerable<Fish> CaughtFishes => _caughtFishes;

		private void Start()
		{
			_circleCollider2D = GetComponent<CircleCollider2D>();
			DisableCollider();
		}

		private void OnTriggerEnter2D([NotNull] Collider2D col)
		{
			var fish = col.gameObject.GetComponent<Fish>();
			if (!fish) return;

			CatchFish(fish);
		}

		public void EnableCollider() => _circleCollider2D.enabled = true;

		public void DisableCollider() => _circleCollider2D.enabled = false;

		public void ReleaseFishes()
		{
			_caughtFishes.ForEach(fish => fish.ReturnToPool());
			_caughtFishes.Clear();
		}

		private void CatchFish([NotNull] Fish fish)
		{
			fish.gameObject.transform.parent = transform;
			fish.transform.localPosition = new Vector3(3, 0, 0);
			fish.Stop();
			_caughtFishes.Add(fish);
		}
	}
}
