using System;
using System.Diagnostics;
using UnityEngine;

namespace GameParameters
{
    public abstract class DurationBase : GameParameterBase
    {
        [SerializeField] protected Length Length;

        public override event Action OnValueUpdate;
        protected abstract float DefaultValue { get; }

        private void OnEnable()
        {
            Length.OnValueUpdate += Сorrelate;
        }

        private void OnDisable()
        {
            Length.OnValueUpdate -= Сorrelate;
        }

        public override void ToDefault()
        {
            Value = DefaultValue;
            OnValueUpdate?.Invoke();
        }

        protected virtual void Сorrelate()
        {
            OnValueUpdate?.Invoke();
        }
    }
}