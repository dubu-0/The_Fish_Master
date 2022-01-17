using DG.Tweening;
using Fishing.Fishes.Spawn;
using Fishing.Movement;
using Parameters.MoneyParameter;
using UnityEngine;

namespace Fishing.Fishes
{
	[RequireComponent(typeof(Collider2D))]
	public class Fish : PooledObjectBase
	{
		[SerializeField] private float maxSpeed;
		[SerializeField] private float _cost;

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

		public void IncreaseMoney(Money money) => money.IncreaseBy(_cost);
		
		public void Stop()
		{
			_isStopped = true;
			_collider.enabled = false;
		}

		public void StartShaking()
		{
			transform.DOShakeRotation(5f).SetLoops(-1, LoopType.Yoyo);
		}

		public void LookUp()
		{
			transform.up = Vector3.up;
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
