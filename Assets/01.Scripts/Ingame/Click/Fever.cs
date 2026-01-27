using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Fever : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float _feverDuration = 5f;
    private static WaitForSeconds _wait;

    private bool _isFeverMode = false;
    private Stage _stage;
    private Value _damage;

    private void Start()
    {
        _wait = new(_feverDuration);
        _damage = GameManager.Instance.ManualDamage;
        _stage = GameManager.Instance.Stage;
        _stage.OnFeverStarted += StartFeverRoutine;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _stage.OnFeverStarted -= StartFeverRoutine;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!_isFeverMode) return;
        AttackAllSlimes();
    }

    private void AttackAllSlimes()
    {
        ClickInfo feverInfo = new(EClickType.Fever, _damage.Amount);

        var targets = GameManager.Instance.Slimes;

        foreach (var slime in targets)
        {
            slime.OnClick(feverInfo);
        }
    }

    private void StartFeverRoutine()
    {
        if (_isFeverMode) return;
        _isFeverMode = true;
        gameObject.SetActive(true);
        StartCoroutine(FeverTimer());
    }

    private IEnumerator FeverTimer()
    {
        // 여기에 피버 UI 켜기 등의 연출 추가 가능

        yield return _wait;

        EndFever();
    }

    private void EndFever()
    {
        _isFeverMode = false;
        gameObject.SetActive(false);
    }
}
