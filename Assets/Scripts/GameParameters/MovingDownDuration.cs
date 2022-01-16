using UnityEngine;

namespace GameParameters
{
    [CreateAssetMenu(menuName = "Create MovingDownDuration", fileName = "MovingDownDuration", order = 0)]
    public class MovingDownDuration : DurationBase
    {
        protected override float DefaultValue => 1.2f;
    }
}