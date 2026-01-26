using UnityEngine;

public class ClickTarget : MonoBehaviour, IClickable
{
    [Header("설정")]
    [SerializeField] private int _level;
    [SerializeField] private int _maxHealth;
    [SerializeField] private Value _health;
    [SerializeField] private int _goldReward;
    [SerializeField] private int _expReward;
    
    private IFeedback[] _feedbacks;
    
    private void Awake()
    {
        _feedbacks = GetComponents<IFeedback>();
    }

    public void Initialize(int level)
    {
        _level = level;
        _health.SetValue(level * _maxHealth);
    }

    public bool OnClick(ClickInfo info)
    {
        if (_health.Amount <= 0) return false;
        
        _health.SubValue(info.Damage);
        
        foreach (var feedback in _feedbacks)
        {
            feedback.Play(info);
        }

        if (_health.Amount > 0)
        {
            Death();
        }
        return true;
    }

    private void Death()
    {
        GameManager.Instance.GetReward(_goldReward, _expReward);
        Destroy(gameObject, 2f);
    }
}
