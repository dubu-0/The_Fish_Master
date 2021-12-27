using System.Collections.Generic;
using Fishes.Spawn;
using JetBrains.Annotations;
using UnityEngine;

namespace FishingGear.FishingLine
{
	[RequireComponent(typeof(CircleCollider2D))]
	public sealed class Hook : MonoBehaviour
	{
		private readonly List<IPoolable> _caught = new List<IPoolable>();
		private CircleCollider2D _circleCollider2D;

		public IEnumerable<IPoolable> Caught => _caught;

		private void Start()
		{
			_circleCollider2D = GetComponent<CircleCollider2D>();
			DisableCollider();
		}

		private void OnTriggerEnter2D([NotNull] Collider2D col)
		{
			var poolable = col.gameObject.GetComponent<IPoolable>();
			if (poolable == null) return;

			Catch(poolable);
		}

		public void EnableCollider() => _circleCollider2D.enabled = true;

		public void DisableCollider() => _circleCollider2D.enabled = false;

		public void Release()
		{
			_caught.ForEach(poolable => poolable.ReturnToPool());
			_caught.Clear();
		}

		private void Catch([NotNull] IPoolable poolable)
		{
			poolable.GameObject.transform.parent = transform;
			poolable.GameObject.transform.localPosition = new Vector3(3, 0, 0);
			poolable.Stop();
			_caught.Add(poolable);
		}
	}
}
