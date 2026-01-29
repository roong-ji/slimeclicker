using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UpgradeButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private GameObject _hideButton;
    
    public event Action OnClick;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClick?.Invoke();
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _hideButton.SetActive(false);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _hideButton.SetActive(true);
    }
}
