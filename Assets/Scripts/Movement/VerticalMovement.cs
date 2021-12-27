using System;
using System.Collections;
using JetBrains.Annotations;
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

	public static class TransformExtension
	{
		public static IEnumerator MoveDownFast
			([NotNull] this Transform transform, float toLevel, float additionalSpeed, VerticalMovement verticalMovement)
		{
			const float direction = -1f;

			while (transform.position.y > toLevel)
			{
				transform.position = verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				yield return null;
			}
		}

		public static IEnumerator MoveUpSlow
		(
			[NotNull] this Transform transform,
			float toLevel,
			float additionalSpeed,
			VerticalMovement verticalMovement,
			Func<bool> whenToStop
		)
		{
			const float direction = 1f;

			while (transform.position.y < toLevel)
			{
				if (whenToStop.Invoke()) yield break;

				transform.position = verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				yield return null;
			}
		}

		public static IEnumerator MoveUpFast
			([NotNull] this Transform transform, float toLevel, float additionalSpeed, VerticalMovement verticalMovement)
		{
			const float direction = 1f;

			while (transform.position.y < toLevel)
			{
				transform.position = verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				yield return null;
			}
		}
	}
}
