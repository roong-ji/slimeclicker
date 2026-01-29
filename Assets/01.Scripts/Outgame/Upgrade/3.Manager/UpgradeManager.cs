using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{
    [SerializeField] private UpgradeDataTableSO _dataSO;
    private readonly Dictionary<EStatType, Upgrade> _upgrades = new();
    
    protected override void OnInit()
    {
        foreach (var data in _dataSO.Datas)
        {
            var upgrade = new Upgrade(data.Value);
            _upgrades.Add(data.Key, upgrade);
        }
    }

    public double GetCost(EStatType statType)
    {
        var upgrade = _upgrades.GetValueOrDefault(statType);
        return upgrade.Cost;
        
    }
    
    public bool TryUpgrade(EStatType statType)
    {
        var upgrade = _upgrades.GetValueOrDefault(statType);
        var cost = upgrade.Cost;

        if (!CurrencyManager.Instance.TrySpend(cost) 
            || !upgrade.TryLevelUp()) return false;
        
        var value = upgrade.Value;
        StatManager.Instance.SetStat(statType, value);
        
        return true;
    }
}