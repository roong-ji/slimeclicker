using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TextPresenter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string _text;
    [SerializeField] private TextMeshProUGUI _textUI;
    private Value _value;

    public void Initialize(Value value)
    {
        _value = value;
        value.OnValueChanged += Refresh;
    }
    
    private void Refresh(double amount)
    {
        _textUI.SetText(amount.ToUnitString());
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Tooltip.Instance.Show(_text);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Tooltip.Instance.Hide();
    }
}
