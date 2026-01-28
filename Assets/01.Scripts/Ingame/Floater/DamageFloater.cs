using UnityEngine;
using TMPro;
using DG.Tweening;
using Lean.Pool;

public class DamageFloater : MonoBehaviour
{
    [SerializeField] private TextMeshPro _damageTextUI;
    
    [Header("Settings")]
    [SerializeField] private float _targetScale = 2f;
    [SerializeField] private float _scaleDownDuration = 0.3f;
    [SerializeField] private float _scaleUpDuration = 0.3f;
    [SerializeField] private float _fadeStartTime = 0.8f;
    [SerializeField] private float _fadeDuration = 0.2f;

    private Sequence _sequence;

    public void Show(double damage)
    {
        _damageTextUI.SetText(damage.ToUnitString());
        _damageTextUI.alpha = 1f;
        transform.localScale = Vector3.one;

        _sequence?.Kill();
        _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOScale(_targetScale, _scaleDownDuration).SetEase(Ease.OutQuad));      
        
        _sequence.Insert(_scaleDownDuration, transform.DOScale(1f, _scaleUpDuration).SetEase(Ease.InQuad));
        
        _sequence.Insert(_fadeStartTime, _damageTextUI.DOFade(0, _fadeDuration).SetEase(Ease.InQuad));

        _sequence.OnComplete(() => 
        {
            LeanPool.Despawn(gameObject);
        });
    }
}
