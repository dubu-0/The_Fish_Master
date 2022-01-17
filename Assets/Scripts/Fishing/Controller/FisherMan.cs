using DG.Tweening;
using Fishing.Gear;
using Parameters.DurationParameters;
using Parameters.GameParameters;
using UnityEngine;
using FishingLine = Fishing.Gear.FishingLine;

namespace Fishing.Controller
{
	public class FisherMan : MonoBehaviour
	{
		[SerializeField] private FishingLine _fishingLine;
		[SerializeField] private Hook _hook;
		[SerializeField] private MovingDownDurationParameter _movingDownDuration;
		[SerializeField] private MovingUpDurationParameter _movingUpDuration;
		[SerializeField] private LengthParameter _lengthParameter;
		[SerializeField] private StrengthParameter _strengthParameter;
		
		private Sequence _fishingSequence;

		private void Update()
		{
			StopFishing(when: HookHasMaximumFishes());
		}

		public void StartFishing()
		{
			if (IsFishingStarted()) return;
			
			_fishingSequence = BuildNewSequence(Ease.Linear);
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

		private bool IsFishingStarted() => _fishingSequence != null;

		private bool HookHasMaximumFishes()
		{
			return _hook.CaughtCount >= _strengthParameter.CurrentValue;
		}

		private Sequence BuildNewSequence(Ease ease)
		{
			var newSequence = DOTween.Sequence();
			
			newSequence
				.Append(_fishingLine.BuildMovingSequence(-_lengthParameter.CurrentValue, _movingDownDuration.CurrentValue, ease)
				.OnComplete(() => _hook.EnableCollider()));
                
			newSequence
				.Append(_fishingLine.BuildMovingSequence(0, _movingUpDuration.CurrentValue, ease)
				.OnComplete(() => _hook.Release()));

			return newSequence;
		}

	}
}
