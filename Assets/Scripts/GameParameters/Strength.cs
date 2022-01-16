using System;
using UnityEngine;

namespace GameParameters
{
    [CreateAssetMenu(menuName = "Create Strength", fileName = "Strength", order = 0)]
    public class Strength : GameParameterBase
    {
        [SerializeField] private Money _money;
        [SerializeField] private float _cost;
        [SerializeField, Range(1.1f, 2f)] private float _costRateOfChange;

        public override event Action OnValueUpdate;
        
        private float DefaultStrength => 3;
        private float DefaultCost => 200;

        public override void ToDefault()
        {
            Value = DefaultStrength;
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