using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Parameters.GameParameters.OfflineEarnings
{
    public class OfflineEarningsUI : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private OfflineEarningsParameter _offlineEarningsParameter;

        private void OnEnable()
        {
            _offlineEarningsParameter.OnValueUpdate += UpdateText;
        }

        private void Start()
        {
            UpdateText();
        }

        private void OnDisable()
        {
            _offlineEarningsParameter.OnValueUpdate -= UpdateText;
        }

        private void UpdateText()
        {
            _text.text = _offlineEarningsParameter.CurrentValue.ToString(CultureInfo.CurrentCulture);
        }
    }
}
