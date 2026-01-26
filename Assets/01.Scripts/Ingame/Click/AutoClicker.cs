using System.Collections.Generic;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    private Value _damage;
    [SerializeField] private float _speed;
    private float _timer;

    [SerializeField] private SlimeSpawner _spawner;
    private List<IClickable> _clickables = new();
    
    private void Start()
    {
        _timer = 0;
        foreach (var slime in _spawner.Slimes)
        {
            if (!slime.TryGetComponent(out IClickable clickable)) return;
            _clickables.Add(clickable);
        }

        _damage = GameManager.Instance.AutoDamage;
    }
    
    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < 1 / _speed) return;
        _timer = 0;

        ClickInfo clickInfo = new(EClickType.Auto, _damage.Amount);
            
        foreach (var clickable in _clickables)
        {
            clickable.OnClick(clickInfo);
        }
    }
}
