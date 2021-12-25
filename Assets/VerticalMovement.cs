using UnityEngine;

public sealed class VerticalMovement
{
	private Vector3 _currentPosition;
	private float _velocity;

	public VerticalMovement(float velocity, Vector3 currentPosition)
	{
		_velocity = velocity;
		_currentPosition = currentPosition;
	}

	public Vector3 SmoothStep()
	{
		_currentPosition.y += _velocity * Time.deltaTime;
		return _currentPosition;
	}

	public void ChangeDirection() => _velocity = -_velocity;

	public void MultiplySpeedBy(float value) => _velocity *= Mathf.Abs(value);

	public void Stop() => _velocity *= 0;
}
