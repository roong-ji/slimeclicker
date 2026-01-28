using TMPro;
using UnityEngine;
using DG.Tweening;

public class ValuePresenter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textUI;
    private IReadOnlyValue _value;

    [Header("Tween Settings")]
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private Ease _ease = Ease.OutQuad;
    private Tween _countTween;
    private double _displayedValue;
    
    public void Initialize(IReadOnlyValue value)
    {
        _value = value;
        _textUI.SetText(value.Amount.ToUnitString());
        _value.OnChanged += Refresh;
    }

    private void OnDestroy()
    {
        _value.OnChanged -= Refresh;
    }

    private void Refresh(double amount)
    {
        _countTween?.Kill();

        _countTween = DOTween.To(() => _displayedValue, x =>
        {
            _displayedValue = x;
            _textUI.SetText(_displayedValue.ToUnitString());
        }, amount, _duration)
            .SetEase(_ease);
    }
}
