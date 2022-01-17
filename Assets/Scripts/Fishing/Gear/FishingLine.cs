using DG.Tweening;
using UnityEngine;

namespace Fishing.Gear
{
	public class FishingLine : MonoBehaviour
	{
		public Sequence BuildMovingSequence(float endValue, float duration, Ease ease)
		{
			var movingSequence = DOTween.Sequence();
			movingSequence.Join(DoLocalMoveY(endValue, duration, ease));
			return movingSequence;
		}

		private Tween DoLocalMoveY(float endValue, float duration, Ease ease)
		{
			var transformTween = transform
				.DOLocalMoveY(endValue, duration);

			return transformTween;
		}
	}
}
