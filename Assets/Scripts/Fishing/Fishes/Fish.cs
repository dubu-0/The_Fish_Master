using Fishing.Fishes.Spawn;
using Fishing.Movement;
using UnityEngine;

namespace Fishing.Fishes
{
	[RequireComponent(typeof(Collider2D))]
	public sealed class Fish : PooledObjectBase
	{
		[SerializeField] private float maxSpeed;

		private Collider2D _collider;
		private HorizontalMovement _horizontalMovement;
		private bool _isStopped;
		private float _currentSpeed;

		private void Start()
		{
			CreateHorizontalMovement();
			SetCurrentSpeedToRandom();
			SetCollider2D();
		}

		private void Update()
		{
			if (_isStopped) return;

			PingPong();
		}

		public void SetLocalPosition(Vector3 newLocalPosition) => transform.localPosition = newLocalPosition;

		public void SetNewParent(Transform newParent) => transform.parent = newParent;

		public void Stop()
		{
			_isStopped = true;
			_collider.enabled = false;
		}

		private void CreateHorizontalMovement()
		{
			_horizontalMovement = new HorizontalMovement(transform.localScale);
		}

		private void SetCurrentSpeedToRandom()
		{
			const float fraction = 0.5f;
			_currentSpeed = _horizontalMovement.GetRandomSpeed(maxSpeed * fraction, maxSpeed);
		}

		private void SetCollider2D()
		{
			_collider = GetComponent<Collider2D>();
		}

		private void PingPong()
		{
			var newTransform = _horizontalMovement.PingPong(transform, Time.time, _currentSpeed);

			transform.localPosition = newTransform.localPosition;
			transform.localScale = newTransform.localScale;
		}
	}
}
