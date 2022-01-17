using UnityEngine;

namespace Parameters
{
    public class ParameterContainer : MonoBehaviour
    {
        [SerializeField] private ParameterBase[] _gameParameters;

        private void OnValidate()
        {
            FillGameParameters();
        }

        public void ToDefaults()
        {
            foreach (var gameParameter in _gameParameters)
            {
                gameParameter.ToDefault();
            }
        }

        private void FillGameParameters()
        {
            var parameters = Resources.FindObjectsOfTypeAll<ParameterBase>();
            _gameParameters = parameters;
        }
    }
}
