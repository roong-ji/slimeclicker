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
    
    public event Action OnClick;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        UpgradeManager.Instance.TryUpgrade(_targetStatType);
        var cost = UpgradeManager.Instance.GetCost(_targetStatType);
        _costTextUI.SetText(cost.ToUnitString());
        _hideCostTextUI.SetText(cost.ToUnitString());
        OnClick?.Invoke();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }
    
    private void Start()
    {
        CurrencyManager.Instance.OnChanged += RefreshUI;
        RefreshUI(CurrencyManager.Instance.Amount);
    }

    private void OnDestroy()
    {
        if (CurrencyManager.Instance == null) return;
        CurrencyManager.Instance.OnChanged -= RefreshUI;
    }
    
    private void RefreshUI(double gold)
    {
        var cost = UpgradeManager.Instance.GetCost(_targetStatType);
        _hideButton.SetActive(gold < cost);
    }
}
