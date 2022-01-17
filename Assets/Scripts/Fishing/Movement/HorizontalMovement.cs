using UnityEngine;

namespace Fishing.Movement
{
	public class HorizontalMovement
	{
		private readonly float _halfScreenWidth;
		private Vector3 _currentLocalScale;

		public HorizontalMovement(Vector3 currentLocalScale)
		{
			_currentLocalScale = currentLocalScale;
			_halfScreenWidth = Camera.main!.orthographicSize / 2f;
		}

		public Transform PingPong(Transform current, float time, float speed)
		{
			var newHorizontalPosition = (Mathf.PingPong(time * speed, 2) - 1) * _halfScreenWidth;
			var newLocalPosition = current.localPosition;
			var newLocalScale = UpdateLookDirection(newHorizontalPosition - newLocalPosition.x);

			newLocalPosition.x = newHorizontalPosition;

			current.localScale = newLocalScale;
			current.localPosition = newLocalPosition;
			
			return current;
		}

		public float GetRandomSpeed(float min, float max) => Random.Range(min, max);

		private Vector3 UpdateLookDirection(float deltaX)
		{
			var newScaleY = Mathf.Sign(deltaX) * Mathf.Abs(_currentLocalScale.y);
			_currentLocalScale.y = newScaleY;
			return _currentLocalScale;
		}
	}
}
