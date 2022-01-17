using Parameters.MoneyParameter;
using UnityEngine;

namespace Parameters.GameParameters.OfflineEarnings
{
    public class OfflineEarningsUpdater : MonoBehaviour
    {
        [SerializeField] private OfflineEarningsParameter _offlineEarningsParameter;
        [SerializeField] private Money _money;

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                _offlineEarningsParameter.CalculateEarnings();
                _money.IncreaseBy(_offlineEarningsParameter.EarnedWhenGameDisabled);
            }
            else
            {
                _offlineEarningsParameter.UpdateSecondsSinceGameDisabled();
            }
        }
    }
}
