using Movement;
using UnityEngine;

namespace Fishes.Species
{
	public abstract class Fish : MonoBehaviour
	{
		[SerializeField] private float maxSpeed;

		private HorizontalMovement _horizontalMovement;

		private float CurrentSpeed { get; set; }

		protected void Start()
		{
			var halfScreenWidth = Camera.main!.orthographicSize / 2;
			_horizontalMovement = new HorizontalMovement(transform.position, transform.localScale, halfScreenWidth);

			const float fraction = 0.5f;
			CurrentSpeed = _horizontalMovement.GetRandomSpeed(maxSpeed * fraction, maxSpeed);
		}

		protected void Update()
		{
			var newPosition = _horizontalMovement.UpdateHorizontalPosition(Time.time, CurrentSpeed, out var newLookDirection);

			transform.localScale = newLookDirection;
			transform.position = newPosition;
		}
	}
}
