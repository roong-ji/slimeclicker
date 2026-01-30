using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{
    [SerializeField] private UpgradeDataTableSO _dataSO;
    private Dictionary<EStatType, Upgrade> _upgrades;

    private IRepository<Dictionary<EStatType, Upgrade>> _repository;
    
    protected override void OnInit()
    {
        _repository = new LocalUpgradeRepository(_dataSO);
        _upgrades = _repository.Load();
    }

    public Upgrade GetUpgrade(EStatType statType)
    {
        return _upgrades.GetValueOrDefault(statType);
    }
    
    public bool TryUpgrade(EStatType statType)
    {
        var upgrade = _upgrades.GetValueOrDefault(statType);
        var cost = upgrade.Cost;

        if (upgrade.IsMaxLevel
            || !CurrencyManager.Instance.TrySpend(cost) 
            || !upgrade.TryLevelUp()) return false;
        
        var value = upgrade.Value;
        StatManager.Instance.SetStat(statType, value);
        
        return true;
    }

    private void OnApplicationQuit()
    {
        _repository.Save(_upgrades);
    }
}