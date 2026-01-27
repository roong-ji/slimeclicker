using UnityEngine;
using UnityEngine.UI;

public class SlimeHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private Value _healthReference;
    private int _maxHp;

    // 슬라임이 초기화될 때 호출해줄 함수
    public void Setup(Value health)
    {
        _healthReference = health;
        _maxHp = health.Amount;

        // 슬라이더 초기 설정
        _slider.maxValue = 1f;
        UpdateSlider(health.Amount);

        // 이벤트 구독 (데이터가 변하면 UI도 변하게 함)
        _healthReference.OnValueChanged += UpdateSlider;
    }

    private void UpdateSlider(int currentHp)
    {
        // 0 ~ 1 사이 비율로 계산
        _slider.value = (float)currentHp / _maxHp;
    }

    private void OnDestroy()
    {
        // 메모리 누수 방지를 위해 이벤트 구독 해제
        if (_healthReference != null)
            _healthReference.OnValueChanged -= UpdateSlider;
    }
}
