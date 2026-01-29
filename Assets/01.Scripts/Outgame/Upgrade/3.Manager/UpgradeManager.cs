using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{
    [SerializeField] private UpgradeDataTableSO _dataSO;
    private readonly Dictionary<EStatType, Upgrade> _upgrades = new();
    
    public event Action<double> OnChanged;

    protected override void OnInit()
    {
        foreach (var data in _dataSO.Datas)
        {
            var upgrade = new Upgrade(data.Value);
            _upgrades.Add(data.Key, upgrade);
        }
    }
}