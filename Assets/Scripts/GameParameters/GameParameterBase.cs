using System;
using UnityEngine;

namespace GameParameters
{
    public abstract class GameParameterBase : ScriptableObject
    {
        [SerializeField] protected float Value;

        public abstract event Action OnValueUpdate;

        public float GetValue => Value;

        public abstract void ToDefault();
    }
}