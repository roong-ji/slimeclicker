using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(CanvasGroup))]
public class FeverTitle : MonoBehaviour
{
    [Header("Tween Settings")]
    [SerializeField] private float _duration = 0.5f;
    [SerializeField] private float _startScale = 0.5f;
    [SerializeField] private float _endScale = 1.2f; // 살짝 커졌다가 돌아오게 설정 가능

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Show()
    {
        // 1. 초기 상태 설정
        _canvasGroup.alpha = 0f;
        transform.localScale = Vector3.one * _startScale;

        // 2. 이전에 돌고 있던 트윈이 있다면 제거 (중복 방지)
        _canvasGroup.DOKill();
        transform.DOKill();

        // 3. 알파 페이드 인 (0 -> 1)
        _canvasGroup.DOFade(1f, _duration);

        // 4. 스케일 업 (작은 상태 -> 원래 크기)
        // SetEase(Ease.OutBack)을 쓰면 띠용~ 하는 탄성 효과가 붙어 더 역동적입니다.
        transform.DOScale(1f, _duration).SetEase(Ease.OutBack);
    }

    public void Hide()
    {
        // 오브젝트가 꺼질 때 트윈 정리
        _canvasGroup.DOKill();
        transform.DOKill();
        _canvasGroup.DOFade(0f, _duration);
    }
}