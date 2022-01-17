using DG.Tweening;
using UnityEngine;

namespace Fishing.Gear
{
	public class FishingLine : MonoBehaviour
	{
		public Sequence BuildMovingSequence(float endValue, float duration, Ease ease)
		{
			var movingSequence = DOTween.Sequence();
			movingSequence.Join(DoLocalMoveY(transform, endValue, duration, ease));
			return movingSequence;
		}

		private Tween DoLocalMoveY(Transform t, float endValue, float duration, Ease ease)
		{
			var transformTween = t
				.DOLocalMoveY(endValue, duration)
				.SetEase(ease);
			
			return transformTween;
		}
	}
}
