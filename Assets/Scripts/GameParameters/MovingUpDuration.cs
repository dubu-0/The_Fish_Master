using UnityEngine;

namespace GameParameters
{
    [CreateAssetMenu(menuName = "Create MovingUpDuration", fileName = "MovingUpDuration", order = 0)]
    public class MovingUpDuration : DurationBase
    {
        protected override float DefaultValue => 8.5f;
        
        protected override void Сorrelate()
        {
            Value = DefaultValue * Length.GetValue * 1 / Length.DefaultLength;
            base.Сorrelate();
        }
    }
}