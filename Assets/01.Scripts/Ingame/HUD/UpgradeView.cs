using TMPro;
using System;
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
    
    public event Action OnClick;
    
    private void Start()
    {
        CurrencyManager.Instance.OnChanged += RefreshButtonUI;
        RefreshButtonUI(CurrencyManager.Instance.Amount);
        RefreshCostUI();
    }

    private void OnDestroy()
    {
        if (CurrencyManager.Instance == null) return;
        CurrencyManager.Instance.OnChanged -= RefreshButtonUI;
    }
    
    private void RefreshButtonUI(double gold)
    {
        var cost = UpgradeManager.Instance.GetCost(_targetStatType);
        var canAfford = gold >= cost;
        _hideButton.SetActive(!canAfford);
        _upgradeImage.SetActive(canAfford);
    }

    private void RefreshCostUI()
    {
        var cost = UpgradeManager.Instance.GetCost(_targetStatType);
        _costTextUI.SetText(cost.ToUnitString());
        _hideCostTextUI.SetText(cost.ToUnitString());
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        UpgradeManager.Instance.TryUpgrade(_targetStatType);
        RefreshCostUI();
        OnClick?.Invoke();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }

}
