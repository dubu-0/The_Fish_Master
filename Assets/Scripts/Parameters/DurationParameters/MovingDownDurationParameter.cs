using UnityEngine;

namespace Parameters.DurationParameters
{
    [CreateAssetMenu(menuName = "Create MovingDownDuration", fileName = "MovingDownDuration", order = 0)]
    public class MovingDownDurationParameter : DurationParameterBase
    {
        public override float DefaultValue => 2f;
    }
}