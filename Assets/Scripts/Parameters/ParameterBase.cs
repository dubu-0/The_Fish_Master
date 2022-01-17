using System;
using UnityEngine;

namespace Parameters
{
    public abstract class ParameterBase : ScriptableObject
    {
        [field: SerializeField] public float CurrentValue { get; protected set; }

        public abstract event Action OnValueUpdate;

        public abstract float DefaultValue { get; }

        public abstract void ToDefault();
    }
}