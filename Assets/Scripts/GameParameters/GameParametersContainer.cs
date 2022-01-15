using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameParameters
{
    public class GameParametersContainer : MonoBehaviour
    {
        [SerializeField] private List<GameParameterBase> _gameParameters;

        private Dictionary<Type, GameParameterBase> _parametersAndTheirTypes;

        private void Start()
        {
            InitializeDictionary();
        }

        public GameParameterBase GetParameterByType<T>() where T : GameParameterBase
        {
            _parametersAndTheirTypes.TryGetValue(typeof(T), out var parameter);

            if (parameter == null)
                throw new NullReferenceException($"{parameter}");

            return parameter;
        }

        private void InitializeDictionary()
        {
            _parametersAndTheirTypes = new Dictionary<Type, GameParameterBase>();

            foreach (var gameParameter in _gameParameters)
            {
                _parametersAndTheirTypes.Add(gameParameter.GetType(), gameParameter);
            }
        }
    }
}
