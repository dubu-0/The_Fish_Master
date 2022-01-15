using UnityEngine;

namespace GameParameters
{
    public abstract class GameParameterBase : ScriptableObject
    {
        [SerializeField] private float _value;

        public float Value => _value;
    }
}