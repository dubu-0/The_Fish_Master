using UnityEngine;

namespace Fishes
{
	public sealed class HorizontalMovement
	{
		private readonly float _halfScreenWidth;
		private Vector3 _currentLocalScale;

		public HorizontalMovement(Vector3 currentLocalScale, float halfScreenWidth)
		{
			_halfScreenWidth = halfScreenWidth;
			_currentLocalScale = currentLocalScale;
		}

		public Vector3 UpdateHorizontalPosition(Vector3 currentPosition, float time, float speed, out Vector3 lookDirection)
		{
			var newPositionX = (Mathf.PingPong(time * speed, 2) - 1) * _halfScreenWidth;
			lookDirection = UpdateLookDirection(currentPosition, newPositionX);
			currentPosition.x = newPositionX;
			return currentPosition;
		}

		public float GetRandomSpeed(float min, float max) => Random.Range(min, max);

		private Vector3 UpdateLookDirection(Vector3 currentPosition, float newPositionX)
		{
			var newScaleY = Mathf.Sign(newPositionX - currentPosition.x) * Mathf.Abs(_currentLocalScale.y);
			_currentLocalScale.y = newScaleY;
			return _currentLocalScale;
		}
	}
}
