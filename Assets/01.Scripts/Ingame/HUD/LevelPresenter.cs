using TMPro;
using UnityEngine;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textUI;
    private Value _level;
    
    public void Initialize(Value level)
    {
        _level = level;
        Refresh(level.Amount);
        level.OnValueChanged += Refresh;
    }
    
    private void Refresh(double amount)
    {
        _textUI.SetText("Lv.{0}", (int)amount);
    }
}
