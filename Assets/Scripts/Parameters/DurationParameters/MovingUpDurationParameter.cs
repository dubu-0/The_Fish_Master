using UnityEngine;

namespace Parameters.DurationParameters
{
    [CreateAssetMenu(menuName = "Create MovingUpDuration", fileName = "MovingUpDuration", order = 0)]
    public class MovingUpDurationParameter : DurationParameterBase
    {
        public override float DefaultValue => 8.5f;
        
        protected override void Сorrelate()
        {
            Value = DefaultValue * _lengthParameter.CurrentValue * 1 / _lengthParameter.DefaultValue;
            base.Сorrelate();
        }
    }
}