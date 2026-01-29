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
    [SerializeField] private TextMeshProUGUI _hideCostTextUI;
    
    private void Start()
    {
        CurrencyManager.Instance.OnChanged += RefreshUI;
        _upgradeButton.OnClick += OnClickUpgrade;

        RefreshUI(CurrencyManager.Instance.Amount);
    }

    private void OnDestroy()
    {
        _upgradeButton.OnClick -= OnClickUpgrade;
        if (CurrencyManager.Instance == null) return;
        CurrencyManager.Instance.OnChanged -= RefreshUI;
    }
    
    private void OnClickUpgrade()
    {
        UpgradeManager.Instance.TryUpgrade(_targetStatType);
    }
    
    private void RefreshUI(double gold)
    {
        var cost = UpgradeManager.Instance.GetCost(_targetStatType);
        _costTextUI.SetText(cost.ToUnitString());
        _hideCostTextUI.SetText(cost.ToUnitString());
        
        if(gold >= cost) _upgradeButton.Show();
        else _upgradeButton.Hide();
    }
}
