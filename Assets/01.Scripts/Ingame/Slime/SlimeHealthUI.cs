using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    private Stat _healthReference;
    private double _maxHp;

    // 슬라임이 초기화될 때 호출해줄 함수
    public void Setup(Stat health)
    {
        _healthReference = health;
        _maxHp = health.Amount;

        // 슬라이더 초기 설정
        _slider.maxValue = 1f;
        UpdateSlider(health.Amount);

        // 이벤트 구독 (데이터가 변하면 UI도 변하게 함)
        _healthReference.OnChanged += UpdateSlider;
        
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        // 메모리 누수 방지를 위해 이벤트 구독 해제
        if (_healthReference != null)
            _healthReference.OnChanged -= UpdateSlider;
    }
    
    private Coroutine _autoHideRoutine;
    private const float _hidetime = 1.5f;
    private static readonly WaitForSeconds _wait = new(_hidetime);
    
    private void UpdateSlider(double currentHp)
    {
        _slider.value = (float)(currentHp / _maxHp);

        // 맞았을 때 체력바 활성화 및 자동 숨김 처리
        gameObject.SetActive(true);
        if (_autoHideRoutine != null) StopCoroutine(_autoHideRoutine);
        _autoHideRoutine = StartCoroutine(AutoHide());
    }

    private IEnumerator AutoHide()
    {
        yield return _wait;
        gameObject.SetActive(false);
    }
}
