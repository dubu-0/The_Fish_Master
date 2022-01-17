using System;
using UnityEngine;

namespace Parameters.MoneyParameter
{
    [CreateAssetMenu(menuName = "Create Money", fileName = "Money", order = 0)]
    public class Money : ParameterBase
    {
        public override event Action OnValueUpdate;

        public override float DefaultValue => 3000;

        public override void ToDefault()
        {
            CurrentValue = DefaultValue;
            OnValueUpdate?.Invoke();
        }

        public void IncreaseBy(float value)
        {
            CurrentValue += value;
            OnValueUpdate?.Invoke();
        }

        public bool TryDecreaseBy(float value)
        {
            if (CurrentValue - value < 0)
                return false;

            CurrentValue -= value;
            OnValueUpdate?.Invoke();
            return true;
        }
    }
}