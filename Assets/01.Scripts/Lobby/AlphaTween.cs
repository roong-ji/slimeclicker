using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class AlphaTween : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float _speed = 2f; // 깜빡이는 속도
    [SerializeField] private float _minAlpha = 0.2f; // 최소 투명도 (완전 투명 방지)
    [SerializeField] private float _maxAlpha = 1.0f; // 최대 투명도

    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        // CanvasGroup 컴포넌트 캐싱
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        // Mathf.PingPong(현재시간 * 속도, 거리)
        // 0 ~ 1 사이를 왕복하는 값을 생성
        float lerpTime = Mathf.PingPong(Time.time * _speed, 1.0f);

        // Lerp를 이용해 최소~최대 알파값 사이를 부드럽게 전환
        _canvasGroup.alpha = Mathf.Lerp(_minAlpha, _maxAlpha, lerpTime);
    }
}