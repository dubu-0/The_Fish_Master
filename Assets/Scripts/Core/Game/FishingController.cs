using System.Collections;
using Core.Extensions;
using FishingGear.FishingLine;
using UnityEngine;

namespace Core.Game
{
	public sealed class FishingController : MonoBehaviour
	{
		[SerializeField] private GameParameters gameParameters;
		[SerializeField] private FishingLine fishingLine;
		[SerializeField] private Hook hook;
		[SerializeField] [Range(-30f, -50f)] private float goesUpTo;

		private Coroutine _fishing;
		private Camera _main;

		private void Start() => _main = Camera.main;

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && _fishing == null)
				_fishing = StartCoroutine(Fishing());
		}

		private IEnumerator Fishing()
		{
			yield return StartCoroutine(MovingDownFast(100f));

			hook.GetModel().EnableCollider();

			yield return StartCoroutine(MovingUpSlow(8f));

			hook.GetModel().DisableCollider();

			yield return StartCoroutine(MovingUpFast(50f));

			hook.GetModel().Release();

			_fishing = null;
		}

		private IEnumerator MovingDownFast(float speed)
		{
			var offsetY = fishingLine.transform.position.y * 0.35f;

			yield return StartCoroutine(_main.transform.MoveY(fishingLine.transform.position.y + offsetY, speed));

			StartCoroutine(_main.transform.MoveY(-gameParameters.Length + offsetY, speed));
			yield return StartCoroutine(fishingLine.transform.MoveY(-gameParameters.Length, speed));
		}

		private IEnumerator MovingUpSlow(float speed)
		{
			StartCoroutine(_main.transform.MoveY(goesUpTo, speed, () => hook.GetModel().CaughtCount >= gameParameters.Strength));
			yield return StartCoroutine(fishingLine.transform.MoveY(goesUpTo, speed, () => hook.GetModel().CaughtCount >= gameParameters.Strength));
		}

		private IEnumerator MovingUpFast(float speed)
		{
			StartCoroutine(_main.transform.MoveY(fishingLine.StartingPosition.y, speed));
			yield return StartCoroutine(fishingLine.transform.MoveY(fishingLine.StartingPosition.y, speed));
			yield return StartCoroutine(_main!.transform.MoveY(0f, speed));

			_main.transform.position = new Vector3(0, 0, _main.transform.position.z);
		}
	}
}
