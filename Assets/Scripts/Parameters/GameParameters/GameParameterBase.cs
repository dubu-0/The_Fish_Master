using System;
using Parameters.MoneyParameter;
using UnityEngine;

namespace Parameters.GameParameters
{
    public abstract class GameParameterBase : ParameterBase
    {
        [SerializeField] private Money _money;
        [SerializeField] private float _cost;
        [SerializeField, Range(1.1f, 2f)] private float _costRateOfChange;

        public override event Action OnValueUpdate;

        protected abstract float DefaultCost { get; }

        public override void ToDefault()
        {
            Value = DefaultValue;
            _cost = DefaultCost;
            OnValueUpdate?.Invoke();
        }

        public void IncreaseBy(float value)
        {
            if (!_money.TryDecreaseBy(_cost)) return;
            
            Value += value;
            _cost *= _costRateOfChange;
            OnValueUpdate?.Invoke();
        }
    }
}