using UnityEngine;

namespace Fishing.Movement
{
	public sealed class HorizontalMovementByMouse
	{
		private readonly Camera _camera;
		private Vector3 _currentPosition;

		public HorizontalMovementByMouse(Vector3 currentPosition, Camera camera)
		{
			_currentPosition = currentPosition;
			_camera = camera;
		}

		public Vector3 UpdateHorizontalPosition()
		{
			var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
			_currentPosition.x = mousePos.x;
			return _currentPosition;
		}
	}
}
