using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeView : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [Header("Settings")]
    [SerializeField] private EStatType _targetStatType;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _costTextUI;
    [SerializeField] private TextMeshProUGUI _hideCostTextUI;
    
    [SerializeField] private GameObject _hideButton;
    [SerializeField] private GameObject _upgradeImage;

    private Upgrade _upgrade;
    private IReadOnlyValue _currency;
    
    public void Initialize(Upgrade upgrade, IReadOnlyValue currency)
    {
        _upgrade = upgrade;
        _currency = currency;
        
        _upgrade.OnChanged += RefreshCostUI;
        _currency.OnChanged += RefreshButtonUI;
        RefreshButtonUI(currency.Amount);
        RefreshCostUI(upgrade.Cost);
    }

    private void OnDestroy()
    {
        _upgrade.OnChanged -= RefreshCostUI;
        if (_currency == null) return;
        _currency.OnChanged -= RefreshButtonUI;
    }
    
    private void RefreshButtonUI(double gold)
    {
        var cost = _upgrade.Cost;
        var canAfford = gold >= cost;
        _hideButton.SetActive(!canAfford);
        _upgradeImage.SetActive(canAfford);
    }

    private void RefreshCostUI(double cost)
    {
        _costTextUI.SetText(cost.ToUnitString());
        _hideCostTextUI.SetText(cost.ToUnitString());
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        UpgradeManager.Instance.TryUpgrade(_targetStatType);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }
}
