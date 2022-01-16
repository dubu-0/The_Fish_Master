using System;
using UnityEngine;

namespace GameParameters
{
    [CreateAssetMenu(menuName = "Create MovingDownDuration", fileName = "MovingDownDuration", order = 0)]
    public class MovingDownDuration : GameParameterBase
    {
        public override event Action OnValueUpdate;
        private float DefaultValue => 1.5f;

        public override void ToDefault()
        {
            Value = DefaultValue;
            OnValueUpdate?.Invoke();
        }
    }
}