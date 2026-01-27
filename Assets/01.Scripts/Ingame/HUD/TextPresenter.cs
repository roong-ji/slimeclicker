using TMPro;
using UnityEngine;

public class TextPresenter : MonoBehaviour
{
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
}
