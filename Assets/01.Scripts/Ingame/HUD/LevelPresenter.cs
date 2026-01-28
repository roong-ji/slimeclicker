using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelPresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _levelTextUI;
    [SerializeField] private TextMeshProUGUI _expTextUI;
    [SerializeField] private Slider _expSlider;
    [SerializeField] private LevelUpTitle _levelEffect;
    private Level _level;
    
    public void Initialize(Level level)
    {
        _level = level;
        _levelTextUI.SetText("Lv.{0}", level.Value);
        RefreshExp(level.Exp, level.MaxExp);
        _level.OnLevelUp += RefreshLevel;
        _level.OnExpChanged += RefreshExp;
    }

    private void OnDestroy()
    {
        _level.OnLevelUp -= RefreshLevel;
        _level.OnExpChanged -= RefreshExp;
    }
    
    private void RefreshLevel(int level)
    {
        _levelTextUI.SetText("Lv.{0}", level);
        _levelEffect.Play();
    }

    private void RefreshExp(double exp, double maxExp)
    {
        _expTextUI.SetText($"{exp.ToUnitString()} / {maxExp.ToUnitString()}");
        _expSlider.value = (float)(exp / maxExp);
    }
}
