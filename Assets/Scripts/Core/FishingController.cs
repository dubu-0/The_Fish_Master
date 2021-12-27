using System.Collections;
using System.Linq;
using FishingGear.FishingLine;
using UnityEngine;

namespace Core
{
	public sealed class FishingController : MonoBehaviour
	{
		[SerializeField] private FishingLine fishingLine;
		[SerializeField] private Hook hook;
		[SerializeField, Range(-30f, -50f)] private float goesUpTo;
		
		private Coroutine _fishing;
		private float _fishingLineStartPositionY;
		private GameParameters _gameParameters;

		private void Start()
		{
			_fishingLineStartPositionY = fishingLine.transform.position.y;
			_gameParameters = new GameParameters();
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0) && _fishing == null)
				_fishing = StartCoroutine(Fishing());
		}

		private IEnumerator Fishing()
		{
			yield return fishingLine.MovingDownFast(-_gameParameters.Length, 100f);
			
			hook.StartHooking();

			yield return fishingLine.MovingUpSlow(goesUpTo, 0f, () => hook.CaughtFishes.Count() >= _gameParameters.Strength);
			
			hook.StopHooking();
			
			yield return fishingLine.MovingUpFast(_fishingLineStartPositionY, 50f);
			
			hook.ReleaseFishes();

			_fishing = null;
		}
	}
}
