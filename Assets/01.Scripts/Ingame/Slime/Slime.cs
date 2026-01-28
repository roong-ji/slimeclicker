using System.Collections;
using UnityEngine;

public class Slime : MonoBehaviour, IClickable
{
    [Header("설정")]
    [SerializeField] private int _baseHealth;
    [SerializeField] private Value _health;
    [SerializeField] private SlimeHealthUI _healthUI;
    
    private const float DeathTime = 0.5f;
    private static readonly WaitForSeconds _wait = new(DeathTime);
    
    private IClickFeedback[] _clickFeedbacks;
    private ISpawnFeedback[] _spawnFeedbacks;
    private IDespawnFeedback[] _despawnFeedbacks;
    
    private void Awake()
    {
        _clickFeedbacks = GetComponents<IClickFeedback>();
        _spawnFeedbacks = GetComponents<ISpawnFeedback>();
        _despawnFeedbacks = GetComponents<IDespawnFeedback>();
    }

    public void Initialize(float rate)
    {
        _health.SetValue(rate * _baseHealth);
        _healthUI.Setup(_health);

        foreach (var feedback in _spawnFeedbacks)
        {
            feedback.OnSpawn();
        }
    }

    public bool OnClick(ClickInfo info)
    {
        if (_health.Amount <= 0) return false;
        
        _health.SubValue(info.Damage);
        
        foreach (var feedback in _clickFeedbacks)
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
        _healthUI.gameObject.SetActive(false);
        
        yield return _wait;
        
        foreach (var feedback in _despawnFeedbacks)
        {
            feedback.OnDespawn();
        }
        
        GameManager.Instance.UnregisterSlime(this);
        gameObject.SetActive(false);
    }
}
