using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    private Stat _damage;
    [SerializeField] private float _speed;
    private float _timer;
    
    private void Start()
    {
        _timer = 0;
        _damage = GameManager.Instance.AutoDamage;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < 1 / _speed) return;
        _timer = 0;

        ClickInfo clickInfo = new(EClickType.Auto, _damage.Amount);

        var slimes = GameManager.Instance.Slimes;
        foreach (var clickable in slimes)
        {
            clickable.OnClick(clickInfo);
        }
    }
}
