using Fishes.Spawn;
using Movement;
using UnityEngine;

namespace Fishes
{
	[RequireComponent(typeof(Collider2D))]
	public sealed class Fish : MonoBehaviour, IPoolable, IHookable
	{
		[SerializeField] private float maxSpeed;

		private Collider2D _collider;
		private HorizontalMovement _horizontalMovement;
		private ObjectPool _objectPool;
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

		void IHookable.ChangeLocalPosition(Vector3 newPosition) => transform.localPosition = newPosition;

		void IHookable.ChangeParent(Transform newParent) => transform.parent = newParent;

		void IHookable.Release()
		{
			_stopped = false;
			_collider.enabled = true;
			transform.parent = _parent;
			_objectPool.ReturnObjectToPool(gameObject);
		}
		
		void IStoppable.Stop()
		{
			_stopped = true;
			_collider.enabled = false;
		}

		void IPoolable.ReInit(Vector3 position) => transform.position = position;

		void IPoolable.SetObjectPool(ObjectPool pool) => _objectPool = pool;
	}
}
