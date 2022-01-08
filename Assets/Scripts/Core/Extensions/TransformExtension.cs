using System;
using System.Collections;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Extensions
{
	public static class TransformExtension
	{
		public static IEnumerator MoveY([NotNull] this Transform transform, float to, float speed, [CanBeNull] Func<bool> stopMovingEarly = null)
		{
			var epsilon = 0.5f + (speed * 0.02f);
			var direction = Mathf.Sign(to - transform.position.y);

			while (Math.Abs(transform.position.y - to) > epsilon)
			{
				if (stopMovingEarly != null && stopMovingEarly.Invoke()) yield break;

				transform.position = VerticalMovement.SmoothStep(transform.position, direction, speed);
				yield return null;
			}

			var position = transform.position;
			position.y = to;
			transform.position = position;
		}

		private static class VerticalMovement
		{
			public static Vector3 SmoothStep(Vector3 currentPosition, float direction, float speed)
			{
				currentPosition.y += Mathf.Sign(direction) * Mathf.Abs(speed) * Time.deltaTime;
				return currentPosition;
			}
		}
	}
}
