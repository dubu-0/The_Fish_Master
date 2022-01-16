using System;
using UnityEngine;

namespace GameParameters
{
    [CreateAssetMenu(menuName = "Create Money", fileName = "Money", order = 0)]
    public class Money : GameParameterBase
    {
        public override event Action OnValueUpdate;

        private float DefaultValue => 3000;

        public override void ToDefault()
        {
            Value = DefaultValue;
            OnValueUpdate?.Invoke();
        }

        public void IncreaseBy(float value)
        {
            Value += value;
            OnValueUpdate?.Invoke();
        }

        public bool TryDecreaseBy(float value)
        {
            if (Value - value < 0)
                return false;

            Value -= value;
            OnValueUpdate?.Invoke();
            return true;
        }
    }
}