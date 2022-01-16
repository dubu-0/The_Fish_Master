using System.Globalization;
using GameParameters;
using UnityEngine;
using UnityEngine.UI;

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
        _text.text = _money.GetValue.ToString("N", CultureInfo.CurrentCulture);
    }
}
