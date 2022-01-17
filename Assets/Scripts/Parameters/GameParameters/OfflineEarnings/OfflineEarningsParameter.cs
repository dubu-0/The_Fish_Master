using UnityEngine;

namespace Parameters.GameParameters.OfflineEarnings
{
    [CreateAssetMenu(menuName = "Create OfflineEarningsParameter", fileName = "OfflineEarningsParameter", order = 0)]
    public class OfflineEarningsParameter : GameParameterBase
    {
        [SerializeField] private PassedTimespan _passedTimespan;
        [SerializeField] private float _multiplierForTesting = 1f;
        

        public float EarnedWhenGameDisabled { get; private set; }
        public override float DefaultValue => 0f;
        protected override float DefaultCost => 300f;

        public void UpdateSecondsSinceGameDisabled()
        {
            _passedTimespan.UpdateSecondsSinceGameDisabled();
        }

        public void CalculateEarnings()
        {
            _passedTimespan.UpdateSecondsSinceGameEnabled();
            EarnedWhenGameDisabled = Value * _multiplierForTesting * _passedTimespan.CalculateSecondsSinceLastDisabling();

            Debug.Log($"Earned: {EarnedWhenGameDisabled:N}");
        }
    }
}