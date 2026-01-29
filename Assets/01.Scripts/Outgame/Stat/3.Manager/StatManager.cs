using System.Collections.Generic;
using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    private SerializableDictionary<EStatType, Stat> _stats = new();
    public IReadOnlyDictionary<EStatType, Stat> Stats => _stats;

    public bool TryUpgrade(EStatType statType, double amount)
    {
        if (!Stats.TryGetValue(statType, out var stat)) return false;

        stat.AddValue(amount);
        
        return true;
    }
}
