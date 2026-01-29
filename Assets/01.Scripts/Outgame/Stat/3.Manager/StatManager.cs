using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    [SerializeField] private SerializableDictionary<EStatType, Stat> _stats;

    public IReadOnlyValue GetStat(EStatType statType)
    {
        return _stats.GetValueOrDefault(statType);
    }

    public double GetCost(EStatType statType)
    {
        return _stats.GetValueOrDefault(statType).Cost;
    }

    public bool TryUpgrade(EStatType statType)
    {
        if (!_stats.TryGetValue(statType, out var stat)) return false;
        var cost = stat.Cost;
        
        if (!CurrencyManager.Instance.TrySpend(cost)) return false;
        
        stat.LevelUp();
        return true;
    }
}
