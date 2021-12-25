using UnityEngine;

namespace Movement
{
	public sealed class HorizontalMovement
	{
		private readonly float _halfScreenWidth;
		private Vector3 _currentLocalScale;
		private Vector3 _currentPosition;

		public HorizontalMovement(Vector3 currentPosition, Vector3 currentLocalScale, float halfScreenWidth)
		{
			_currentPosition = currentPosition;
			_halfScreenWidth = halfScreenWidth;
			_currentLocalScale = currentLocalScale;
		}

		public Vector3 UpdateHorizontalPosition(float time, float speed, out Vector3 lookDirection)
		{
			var newPositionX = (Mathf.PingPong(time * speed, 2) - 1) * _halfScreenWidth;
			lookDirection = UpdateLookDirection(newPositionX);
			_currentPosition.x = newPositionX;
			return _currentPosition;
		}

		public float GetRandomSpeed(float min, float max) => Random.Range(min, max);

		private Vector3 UpdateLookDirection(float newPositionX)
		{
			var newScaleY = Mathf.Sign(newPositionX - _currentPosition.x) * Mathf.Abs(_currentLocalScale.y);
			_currentLocalScale.y = newScaleY;
			return _currentLocalScale;
		}
	}
}
