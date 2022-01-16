using System;
using UnityEngine;

namespace GameParameters
{
    [CreateAssetMenu(menuName = "Create MovingUpDuration", fileName = "MovingUpDuration", order = 0)]
    public class MovingUpDuration : GameParameterBase
    {
        public override event Action OnValueUpdate;
        private float DefaultValue => 12f;

        public override void ToDefault()
        {
            Value = DefaultValue;
            OnValueUpdate?.Invoke();
        }
    }
}