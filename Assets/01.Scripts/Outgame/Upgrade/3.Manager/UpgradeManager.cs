using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{
    [SerializeField] private UpgradeDataTableSO _dataSO;
    private readonly Dictionary<EStatType, Upgrade> _upgrades = new();

    private IRepository<UpgradeSaveData> _repository;
    
    protected override void OnInit()
    {
        _repository = new LocalUpgradeRepository();
        var saveData = _repository.Load();
        InitSaveData(saveData);
        SetUpgradeStat();
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

    private void InitSaveData(UpgradeSaveData saveData)
    {
        foreach (var info in saveData.SaveData)
        {
            var data = _dataSO.GetData(info.Type);
            var upgrade = new Upgrade(data, info.Type, info.Level);
            _upgrades.Add(info.Type, upgrade);
        }

        foreach (var info in _dataSO.Datas)
        {
            if (_upgrades.ContainsKey(info.Key)) continue;
            var upgrade = new Upgrade(info.Value, info.Key);
            _upgrades.Add(info.Key, upgrade);
        }
    }

    private void SetUpgradeStat()
    {
        foreach (var upgrade in _upgrades)
        {
            StatManager.Instance.SetStat(upgrade.Key, upgrade.Value.Value);
        }
    }

    private void OnApplicationQuit()
    {
        var data = new UpgradeSaveData();
        foreach (var upgrade in _upgrades)
        {
            data.Add(upgrade.Key, upgrade.Value.Level);
        }
        _repository.Save(data);
    }
}