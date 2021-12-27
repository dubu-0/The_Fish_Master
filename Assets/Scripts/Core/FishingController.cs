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
		private GameParameters _gameParameters;
		private Camera _main;

		private void Start()
		{
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
			yield return StartCoroutine(MoveDownFast(100f));

			hook.EnableCollider();

			yield return StartCoroutine(MoveUpSlow(8f));

			hook.DisableCollider();

			yield return StartCoroutine(MoveUpFast(50f));

			hook.ReleaseFishes();

			_fishing = null;
		}

		private IEnumerator MoveDownFast(float speed)
		{
			var offsetY = fishingLine.transform.position.y * 0.35f;

			yield return StartCoroutine(_main.transform.MoveY(fishingLine.transform.position.y + offsetY, speed));

			StartCoroutine(_main.transform.MoveY(-_gameParameters.Length + offsetY, speed));
			yield return StartCoroutine(fishingLine.transform.MoveY(-_gameParameters.Length, speed));
		}

		private IEnumerator MoveUpSlow(float speed)
		{
			StartCoroutine(_main.transform.MoveY(goesUpTo, speed, () => hook.CaughtFishes.Count() >= _gameParameters.Strength));
			yield return StartCoroutine(fishingLine.transform.MoveY(goesUpTo, speed, () => hook.CaughtFishes.Count() >= _gameParameters.Strength));
		}

		private IEnumerator MoveUpFast(float speed)
		{
			StartCoroutine(_main.transform.MoveY(fishingLine.StartingPosition.y, speed));
			yield return StartCoroutine(fishingLine.transform.MoveY(fishingLine.StartingPosition.y, speed));
			yield return StartCoroutine(_main!.transform.MoveY(0f, speed));

			_main.transform.position = new Vector3(0, 0, _main.transform.position.z);
		}
	}
}
