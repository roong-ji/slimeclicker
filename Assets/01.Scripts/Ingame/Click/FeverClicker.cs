using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class FeverClicker : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private FeverTitle _feverTitle;
    [SerializeField] private float _feverDuration = 5f;
    private static WaitForSeconds _wait;

    private Fever _fever;
    private Stat _damage;

    private void Start()
    {
        _wait = new(_feverDuration);
        _damage = GameManager.Instance.ManualDamage;
        _fever = GameManager.Instance.Fever;
        _fever.OnFeverStarted += StartFeverRoutine;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        _fever.OnFeverStarted -= StartFeverRoutine;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
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
        _feverTitle.Show();
        gameObject.SetActive(true);
        StartCoroutine(FeverTimer());
    }

    private IEnumerator FeverTimer()
    {
        yield return _wait;
        EndFever();
    }

    private void EndFever()
    {
        _fever.EndFever();
        _feverTitle.Hide();
        gameObject.SetActive(false);
    }
}
