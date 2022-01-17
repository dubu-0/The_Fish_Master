using UnityEngine;

namespace Parameters.DurationParameters
{
    [CreateAssetMenu(menuName = "Create MovingUpDuration", fileName = "MovingUpDuration", order = 0)]
    public class MovingUpDurationParameter : DurationParameterBase
    {
        public override float DefaultValue => 10f;
        
        protected override void Сorrelate()
        {
            CurrentValue = DefaultValue * _lengthParameter.CurrentValue * 0.01f;
            base.Сorrelate();
        }
    }
}