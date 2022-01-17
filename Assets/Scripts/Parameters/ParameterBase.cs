using System;
using UnityEngine;

namespace Parameters
{
    public abstract class ParameterBase : ScriptableObject
    {
        [SerializeField] protected float Value;

        public abstract event Action OnValueUpdate;

        public abstract float DefaultValue { get; }
        public float CurrentValue => Value;

        public abstract void ToDefault();
    }
}