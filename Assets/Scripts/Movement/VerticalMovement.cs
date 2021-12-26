using UnityEngine;

namespace Movement
{
	public sealed class VerticalMovement
	{
		private readonly float _speed;

		public VerticalMovement(float speed) => _speed = Mathf.Abs(speed);

		public Vector3 SmoothStep(Vector3 currentPosition, float direction, float additionalSpeed = 0)
		{
			currentPosition.y += Mathf.Sign(direction) * (_speed + Mathf.Abs(additionalSpeed)) * Time.deltaTime;
			return currentPosition;
		}
	}
}
