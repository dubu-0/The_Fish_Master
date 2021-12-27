using System.Collections;
using System.Linq;
using Core;
using Movement;
using UnityEngine;

namespace FishingGear.FishingLine
{
	public sealed class FishingLine : MonoBehaviour
	{
		[SerializeField] private Hook hook;
		[SerializeField, Range(1f, 15f)] private float speed;
		[SerializeField, Range(-70f, -100f)] private float goesDownTo;
		[SerializeField, Range(-30f, -50f)] private float goesUpTo;

		private VerticalMovement _verticalMovement;
		private Coroutine _fishing;
		private float _startPositionY;
		private GameParameters _gameParameters;

		private void Start()
		{
			_verticalMovement = new VerticalMovement(speed);
			_gameParameters = new GameParameters();
			_startPositionY = transform.position.y;
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && _fishing == null)
				_fishing = StartCoroutine(Fishing());
		}

		private IEnumerator Fishing()
		{
			yield return StartCoroutine(MoveDownFast(goesDownTo, 100f));

			hook.StartHooking();

			yield return StartCoroutine(MoveUpSlow(goesUpTo, 0f));
			
			hook.StopHooking();
			
			yield return StartCoroutine(MoveUpFast(_startPositionY, 50f));
			
			hook.ReleaseFishes();

			_fishing = null;
		}

		private IEnumerator MoveDownFast(float toLevel, float additionalSpeed)
		{
			const float direction = -1f;

			while (transform.position.y > toLevel)
			{
				transform.position = _verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				yield return null;
			}
		}
		
		private IEnumerator MoveUpSlow(float toLevel, float additionalSpeed)
		{
			const float direction = 1f;

			while (transform.position.y < toLevel)
			{
				transform.position = _verticalMovement.SmoothStep(transform.position, direction, additionalSpeed);
				
				if (hook.CaughtFishes.Count() >= _gameParameters.Strength) yield break;
				
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
