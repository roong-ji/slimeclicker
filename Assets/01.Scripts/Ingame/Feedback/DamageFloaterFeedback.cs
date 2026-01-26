using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamageFloaterFeedback : MonoBehaviour, IFeedback
{
    [SerializeField] private TextMeshProUGUI _damageTextUI;
    [SerializeField] private RectTransform _canvasRect;
    
    [Header("Settings")]
    [SerializeField] private float _targetScale = 2f;
    [SerializeField] private float _scaleDownDuration = 0.3f;
    [SerializeField] private float _scaleUpDuration = 0.3f;
    [SerializeField] private float _randomOffsetRange = 50f;
    [SerializeField] private float _fadeStartTime = 0.8f;
    [SerializeField] private float _fadeDuration = 0.2f;
    
    private Camera _mainCamera;
    
    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    
    public void Play(ClickInfo info)
    {
        Vector3 screenPos = _mainCamera.WorldToScreenPoint(transform.position);
        Vector3 randomOffset = Random.insideUnitCircle * _randomOffsetRange;
        Vector3 spawnPos = screenPos + randomOffset;

        var instance = Instantiate(_damageTextUI, _canvasRect);
        instance.transform.position = spawnPos;

        instance.SetText("{0}", info.Damage);
        instance.alpha = 1f;
        instance.transform.localScale = Vector3.one;
        
        Sequence sequence = DOTween.Sequence();

        sequence.Append(instance.transform.DOScale(_targetScale, _scaleDownDuration).SetEase(Ease.OutQuad));      
        
        sequence.Insert(_scaleDownDuration, instance.transform.DOScale(1f, _scaleUpDuration).SetEase(Ease.InQuad));
        
        sequence.Insert(_fadeStartTime, instance.DOFade(0, _fadeDuration).SetEase(Ease.InQuad));

        sequence.OnComplete(() => 
        {
            Destroy(instance.gameObject);
        });
    }
}
