using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

namespace Parameters.MoneyParameter
{
    public class MoneyUI : MonoBehaviour
    {
        [SerializeField] private Money _money;
        [SerializeField] private Text _text;

        private void OnEnable()
        {
            _money.OnValueUpdate += UpdateText;
        }

        private void Start()
        {
            UpdateText();
        }

        private void OnDisable()
        {
            _money.OnValueUpdate -= UpdateText;
        }

        private void UpdateText()
        {
            _text.text = _money.CurrentValue.ToString("N", CultureInfo.CurrentCulture);
        }
    }
}
