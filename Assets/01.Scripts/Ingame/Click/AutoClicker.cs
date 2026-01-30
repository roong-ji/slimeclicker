using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    private IReadOnlyStat _damage;
    [SerializeField] private float _speed;
    private float _timer;
    
    private void Start()
    {
        _timer = 0;
        _damage = StatManager.Instance.GetStat(EStatType.AutoDamage);
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < 1 / _speed) return;
        _timer = 0;

        ClickInfo clickInfo = new(EClickType.Auto, _damage.FinalStat);

        var slimes = GameManager.Instance.Slimes;
        foreach (var clickable in slimes)
        {
            clickable.OnClick(clickInfo);
        }
    }
}
