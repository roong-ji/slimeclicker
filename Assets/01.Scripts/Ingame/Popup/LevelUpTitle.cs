using UnityEngine;
using DG.Tweening;

public class LevelUpTitle : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _duration = 1.0f;
    [SerializeField] private float _moveDistance = 100f;
    [SerializeField] private Ease _easeType = Ease.OutBack;
    [SerializeField] private AudioClip _levelupClip;
    
    private Vector3 _originPos;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _originPos = transform.localPosition;
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Play()
    {
        transform.DOKill();
        _canvasGroup.DOKill();

        // 초기 세팅
        gameObject.SetActive(true);
        transform.localPosition = _originPos;
        transform.localScale = Vector3.zero;
        _canvasGroup.alpha = 1;
        SoundSpawner.Instance.PlayClip(_levelupClip);
        
        // 1. 스케일 연출 (0에서 1로 커짐)
        transform.DOScale(Vector3.one, _duration * 0.3f)
            .SetEase(_easeType);

        // 2. 위로 이동 연출
        transform.DOLocalMoveY(_originPos.y + _moveDistance, _duration)
            .SetEase(Ease.OutQuart);

        // 3. 투명도 연출 (서서히 사라짐)
        _canvasGroup.DOFade(0, _duration * 0.5f)
            .SetDelay(_duration * 0.5f);
    }
}
