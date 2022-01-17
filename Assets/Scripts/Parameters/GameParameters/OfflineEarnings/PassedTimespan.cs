using System;
using UnityEngine;

namespace Parameters.GameParameters.OfflineEarnings
{
    [Serializable]
    public struct PassedTimespan
    {
        [SerializeField] private float _secondsSinceGameEnabled;
        [SerializeField] private float _secondsSinceGameDisabled;

        public float CalculateSecondsSinceLastDisabling()
        {
            return (float) DateTime.UtcNow.TimeOfDay.TotalSeconds - _secondsSinceGameDisabled;
        }

        public void UpdateSecondsSinceGameEnabled()
        {
            _secondsSinceGameEnabled = (float) DateTime.UtcNow.TimeOfDay.TotalSeconds;
        }
        
        public void UpdateSecondsSinceGameDisabled()
        {
            _secondsSinceGameDisabled = (float) DateTime.UtcNow.TimeOfDay.TotalSeconds;
        }
    }
}