using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePresenter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private EStatType _targetStatType;

    [Header("UI References")]
    [SerializeField] private UpgradeButton _upgradeButton;
    [SerializeField] private TextMeshProUGUI _costTextUI;

    private IReadOnlyValue _stat;
    
    private void Start()
    {
        CurrencyManager.Instance.OnChanged += OnCurrencyChanged;
        _upgradeButton.OnClick += OnClickUpgrade;

        RefreshUI(CurrencyManager.Instance.Amount);
    }

    private void OnDestroy()
    {
        _upgradeButton.OnClick -= OnClickUpgrade;
        if (CurrencyManager.Instance == null) return;
        CurrencyManager.Instance.OnChanged -= OnCurrencyChanged;
    }
    
    private void OnClickUpgrade()
    {
        StatManager.Instance.TryUpgrade(_targetStatType);
    }

    private void OnCurrencyChanged(double gold)
    {
        RefreshUI(gold);
    }

    private void RefreshUI(double gold)
    {
        var cost = StatManager.Instance.GetCost(_targetStatType);
        _costTextUI.SetText(cost.ToUnitString());
        
        if(gold >= cost) _upgradeButton.Show();
        else _upgradeButton.Hide();
    }
}
