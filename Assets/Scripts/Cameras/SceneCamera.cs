using UnityEngine;

namespace Cameras
{
    public class SceneCamera : MonoBehaviour
    {
        [SerializeField] private Transform _escorted;

        private Transform _myTransform;
        private float _startingOffsetY;

        private void Start()
        {
            _myTransform = transform;
            CalculateStartingOffset();
        }

        private void LateUpdate()
        {
            EscortY();
        }

        private void EscortY()
        {
            var myPosition = _myTransform.position;
            myPosition.y = _escorted.position.y - _startingOffsetY;

            _myTransform.position = myPosition;
        }

        private void CalculateStartingOffset()
        {
            _startingOffsetY = Vector2.Distance(_myTransform.position, _escorted.position);
        }
    }
}