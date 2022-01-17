using System;
using Parameters.GameParameters;
using UnityEngine;

namespace Parameters.DurationParameters
{
    public abstract class DurationParameterBase : ParameterBase
    {
        [SerializeField] protected LengthParameter _lengthParameter;

        public override event Action OnValueUpdate;

        private void OnEnable()
        {
            _lengthParameter.OnValueUpdate += Сorrelate;
        }

        private void OnDisable()
        {
            _lengthParameter.OnValueUpdate -= Сorrelate;
        }

        public override void ToDefault()
        {
            CurrentValue = DefaultValue;
            OnValueUpdate?.Invoke();
        }

        protected virtual void Сorrelate()
        {
            OnValueUpdate?.Invoke();
        }
    }
}