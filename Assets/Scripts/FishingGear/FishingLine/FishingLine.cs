using System;
using System.Collections;
using Movement;
using UnityEngine;

namespace FishingGear.FishingLine
{
	public sealed class FishingLine : MonoBehaviour
	{
		[SerializeField, Range(1f, 15f)] private float speed;

		private VerticalMovement _verticalMovement;

		private void Start() => _verticalMovement = new VerticalMovement(speed);

		public Coroutine MovingDownFast(float toLevel, float additionalSpeed) => StartCoroutine(MoveDownFast(toLevel, additionalSpeed));
		public Coroutine MovingUpSlow(float toLevel, float additionalSpeed, Func<bool> whenToStop) => StartCoroutine(MoveUpSlow(toLevel, additionalSpeed, whenToStop));
		public Coroutine MovingUpFast(float toLevel, float additionalSpeed) => StartCoroutine(MoveUpFast(toLevel, additionalSpeed));

		private IEnumerator MoveDownFast(float toLevel, float additionalSpeed)
		{
			const float direction = -1f;

			while (transform.position.y > toLevel)
			{
				transform.position = _verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				yield return null;
			}
		}

		private IEnumerator MoveUpSlow(float toLevel, float additionalSpeed, Func<bool> whenToStop)
		{ 
			const float direction = 1f;

			while (transform.position.y < toLevel)
			{
				Debug.Log("Moving up slow");

				if (whenToStop.Invoke()) yield break;

				transform.position = _verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				yield return null;
			}
		}
		
		private IEnumerator MoveUpFast(float toLevel, float additionalSpeed)
		{
			const float direction = 1f;

			while (transform.position.y < toLevel)
			{
				transform.position = _verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				yield return null;
			}
		}
	}
}
