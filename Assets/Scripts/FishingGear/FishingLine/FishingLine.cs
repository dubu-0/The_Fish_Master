using System;
using System.Collections;
using Movement;
using UnityEngine;

namespace FishingGear.FishingLine
{
	public sealed class FishingLine : MonoBehaviour
	{
		[SerializeField, Range(1f, 1500f)] private float speed;

		private VerticalMovement _verticalMovement;
		private Coroutine _fishing;

		private void Start() => _verticalMovement = new VerticalMovement(speed);

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && _fishing == null)
				_fishing = StartCoroutine(Fishing());
		}

		private IEnumerator Fishing()
		{
			yield return StartCoroutine(MoveTo(-80f, 100f));
			yield return StartCoroutine(MoveTo(-30, 0f));
			yield return StartCoroutine(MoveTo(-10f, 50f));

			_fishing = null;
		}

		private IEnumerator MoveTo(float toLevel, float additionalSpeed)
		{
			additionalSpeed = Mathf.Abs(additionalSpeed);
			
			var direction = Mathf.Sign(toLevel - transform.position.y);
			var epsilon = 0.5f + ((speed + additionalSpeed) * 0.025f);
			
			while (Math.Abs(transform.position.y - toLevel) > epsilon)
			{
				transform.position = _verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				yield return null;
			}
		}
	}
}
