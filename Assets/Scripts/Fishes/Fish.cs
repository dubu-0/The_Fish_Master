using Fishes.Spawn;
using Movement;
using UnityEngine;

namespace Fishes
{
	[RequireComponent(typeof(Collider2D))]
	public sealed class Fish : MonoBehaviour, IPoolable
	{
		[SerializeField] private float maxSpeed;
		[SerializeField] private ObjectPool objectPool;
		private Collider2D _collider;

		private HorizontalMovement _horizontalMovement;
		private Transform _parent;
		private bool _stopped;

		private float CurrentSpeed { get; set; }

		private void Start()
		{
			var halfScreenWidth = Camera.main!.orthographicSize / 2;
			_horizontalMovement = new HorizontalMovement(transform.localScale, halfScreenWidth);

			const float fraction = 0.5f;
			CurrentSpeed = _horizontalMovement.GetRandomSpeed(maxSpeed * fraction, maxSpeed);

			_collider = GetComponent<Collider2D>();
			_parent = transform.parent;
		}

		private void Update()
		{
			if (_stopped) return;

			var newPosition = _horizontalMovement.UpdateHorizontalPosition(transform.position, Time.time, CurrentSpeed, out var newLookDirection);

			transform.localScale = newLookDirection;
			transform.position = newPosition;
		}

		public void ReInit(Vector3 position) => transform.position = position;

		public void Stop()
		{
			_stopped = true;
			_collider.enabled = false;
		}

		public void ReturnToPool()
		{
			_stopped = false;
			_collider.enabled = true;
			transform.parent = _parent;
			objectPool.ReturnObjectToPool(gameObject);
		}
	}
}
