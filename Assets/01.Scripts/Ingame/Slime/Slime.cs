using System.Collections;
using UnityEngine;

public class Slime : MonoBehaviour, IClickable
{
    [Header("설정")]
    [SerializeField] private int _level;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Value _health;
    [SerializeField] private SlimeHealthUI _healthUI;
    
    private const float DeathTime = 0.5f;
    private WaitForSeconds _wait = new(DeathTime);
    
    private IFeedback[] _feedbacks;
    
    private void Awake()
    {
        _feedbacks = GetComponents<IFeedback>();
    }

    public void Initialize(int level)
    {
        _level = level;
        _health.SetValue(level * _maxHealth);
        _healthUI.Setup(_health);
    }

    public bool OnClick(ClickInfo info)
    {
        if (_health.Amount <= 0) return false;
        
        _health.SubValue(info.Damage);
        
        foreach (var feedback in _feedbacks)
        {
            feedback.Play(info);
        }

        if (_health.Amount <= 0)
        {
            Death();
        }
        return true;
    }

    private void Death()
    {
        GameManager.Instance.GetReward();
        StartCoroutine(DeathRoutine());
    }
    
    private IEnumerator DeathRoutine()
    {
        yield return _wait;
        gameObject.SetActive(false);
    }
}
