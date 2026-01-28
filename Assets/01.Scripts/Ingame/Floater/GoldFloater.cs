using DG.Tweening;
using Lean.Pool;
using TMPro;
using UnityEngine;

public class GoldFloater : MonoBehaviour
{
    [Header("UI 연결")]
    [SerializeField] private TextMeshPro _goldTextUI;

    [Header("연출 설정")]
    [SerializeField] private float _moveDistance = 1.5f;
    [SerializeField] private float _duration = 0.8f;
    [SerializeField] private Ease _easeType = Ease.OutQuart;

    private Sequence _sequence;

    public void Show(double gold)
    {
        _goldTextUI.text = $"+ {gold.ToUnitString()}<sprite index=0>";

        _goldTextUI.alpha = 1f;
        transform.localScale = Vector3.one * 0.8f;

        _sequence?.Kill();
        _sequence = DOTween.Sequence();

        _sequence.Join(transform.DOMoveY(transform.position.y + _moveDistance, _duration).SetEase(_easeType)) // 위로 이동
            .Join(transform.DOScale(1.2f, _duration * 0.2f)) // 살짝 커졌다가
            .AppendInterval(_duration * 0.5f) // 잠시 유지 후
            .Append(_goldTextUI.DOFade(0f, _duration * 0.3f)) // 투명해지기
            .OnComplete(() => {
                LeanPool.Despawn(gameObject);
            });
    }

    private void OnDisable()
    {
        _sequence?.Kill();
    }
}
