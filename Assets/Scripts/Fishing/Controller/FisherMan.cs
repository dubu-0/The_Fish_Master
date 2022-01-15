using DG.Tweening;
using Fishing.Gear;
using GameParameters;
using UnityEngine;

namespace Fishing.Controller
{
	public sealed class FisherMan : MonoBehaviour
	{
		[SerializeField] private FishingLine _fishingLine;
		[SerializeField] private Hook _hook;
		[SerializeField] private GameParametersContainer _gameParametersContainer;
		
		private Sequence _fishingSequence;

		private void Update()
		{
			StartFishing(when: Input.GetMouseButtonDown(0) && FishingIsNotStarted());
			StopFishing(when: HookHasMaximumFishes());
		}

		private void StartFishing(bool when)
		{
			if (!when) return;
			
			_fishingSequence = BuildNewSequence(DOTween.Sequence());
		}

		private void StopFishing(bool when)
		{
			if (!when) return;

			const float newTimeScale = 10f;
			SpeedUpMainSequence(newTimeScale);
			DisableHookCollider();

			void SpeedUpMainSequence(float mainSequenceTimeScale) => _fishingSequence.timeScale = mainSequenceTimeScale;
			void DisableHookCollider() => _hook.DisableCollider();
		}

		private bool FishingIsNotStarted() => _fishingSequence == null;

		private bool HookHasMaximumFishes()
		{
			var strength = _gameParametersContainer.GetParameterByType<Strength>();
			return _hook.CaughtCount >= strength.Value;
		}

		private Sequence BuildNewSequence(Sequence newSequence)
		{
			var length = _gameParametersContainer.GetParameterByType<Length>();
			var movingDownDuration = _gameParametersContainer.GetParameterByType<MovingDownDuration>();
			var movingUpDuration = _gameParametersContainer.GetParameterByType<MovingUpDuration>();
			
			newSequence.Append(_fishingLine.BuildMovingSequence(-length.Value, movingDownDuration.Value, Ease.Linear)
				.OnComplete(() => _hook.EnableCollider()));
                
			newSequence.Append(_fishingLine.BuildMovingSequence(0, movingUpDuration.Value, Ease.Linear)
				.OnComplete(() => _hook.Release()));

			return newSequence;
		}

	}
}
