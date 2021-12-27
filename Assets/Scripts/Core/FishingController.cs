using System.Collections;
using System.Linq;
using FishingGear.FishingLine;
using Movement;
using UnityEngine;

namespace Core
{
	public sealed class FishingController : MonoBehaviour
	{
		[SerializeField] private FishingLine fishingLine;
		[SerializeField] private Hook hook;
		[SerializeField] [Range(-30f, -50f)] private float goesUpTo;

		private Coroutine _fishing;
		private float _fishingLineStartPositionY;
		private GameParameters _gameParameters;
		private Camera _main;

		private void Start()
		{
			_fishingLineStartPositionY = fishingLine.transform.position.y;
			_gameParameters = new GameParameters();
			_main = Camera.main;
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && _fishing == null)
				_fishing = StartCoroutine(Fishing());
		}

		private IEnumerator Fishing()
		{
			yield return StartCoroutine(MoveDownFast());

			hook.EnableCollider();

			yield return StartCoroutine(MoveUpSlow());

			hook.DisableCollider();

			yield return StartCoroutine(MoveUpFast());

			hook.ReleaseFishes();

			_fishing = null;
		}

		private IEnumerator MoveDownFast()
		{
			var offsetY = fishingLine.transform.position.y * 0.35f;

			yield return StartCoroutine
				(_main.transform.MoveDownFast(fishingLine.transform.position.y + offsetY, 100f, fishingLine.VerticalMovement));

			StartCoroutine(_main.transform.MoveDownFast(-_gameParameters.Length + offsetY, 100f, fishingLine.VerticalMovement));
			yield return StartCoroutine(fishingLine.transform.MoveDownFast(-_gameParameters.Length, 100f, fishingLine.VerticalMovement));
		}

		private IEnumerator MoveUpSlow()
		{
			StartCoroutine
			(
				_main.transform.MoveUpSlow
					(goesUpTo, 0f, fishingLine.VerticalMovement, () => hook.CaughtFishes.Count() >= _gameParameters.Strength)
			);

			yield return StartCoroutine
			(
				fishingLine.transform.MoveUpSlow
					(goesUpTo, 0f, fishingLine.VerticalMovement, () => hook.CaughtFishes.Count() >= _gameParameters.Strength)
			);
		}

		private IEnumerator MoveUpFast()
		{
			StartCoroutine(_main.transform.MoveUpFast(_fishingLineStartPositionY, 50f, fishingLine.VerticalMovement));
			yield return StartCoroutine(fishingLine.transform.MoveUpFast(_fishingLineStartPositionY, 50f, fishingLine.VerticalMovement));
			yield return StartCoroutine(_main!.transform.MoveUpFast(0f, 50f, fishingLine.VerticalMovement));
			
			_main.transform.position = new Vector3(0, 0, _main.transform.position.z);
		}
	}
}
