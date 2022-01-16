using System;
using UnityEngine;

namespace GameParameters
{
    [CreateAssetMenu(menuName = "Create Length", fileName = "Length", order = 0)]
    public class Length : GameParameterBase
    {
        [SerializeField] private MovingDownDuration _movingDownDuration;
        [SerializeField] private MovingUpDuration _movingUpDuration;
        [SerializeField] private Money _money;
        [SerializeField] private float _cost;
        [SerializeField, Range(1.1f, 2f)] private float _costRateOfChange;

        public override event Action OnValueUpdate;

        public float DefaultLength => 100;
        private float DefaultCost => 100;

        public override void ToDefault()
        {
            Value = DefaultLength;
            _cost = DefaultCost;
            OnValueUpdate?.Invoke();
        }

        public void IncreaseBy(float value)
        {
            if (!_money.TryDecreaseBy(_cost)) return;
            
            Value += value;
            OnValueUpdate?.Invoke();

            _cost *= _costRateOfChange;
        }
    }
}