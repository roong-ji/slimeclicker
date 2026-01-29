using System.Collections.Generic;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    [SerializeField] private Stat _manualDamage; 
    [SerializeField] private Stat _autoDamage;
    [SerializeField] private Stat _goldReward;
    [SerializeField] private Stat _expReward;
    
    public Stat ManualDamage => _manualDamage;
    public Stat AutoDamage => _autoDamage;
    public Stat GoldReward => _goldReward;
    public Stat ExpReward => _expReward;
    
    private Dictionary<EStatType, Stat> _stats = new();

    protected override void OnInit()
    {
        _stats.Add
    }
}
