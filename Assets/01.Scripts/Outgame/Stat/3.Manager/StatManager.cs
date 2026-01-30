using UnityEngine;

public class StatManager : Singleton<StatManager>
{
    [SerializeField] private SerializableDictionary<EStatType, Stat> _stats;
    
    public IReadOnlyStat GetStat(EStatType statType)
    {
        return _stats.GetValueOrDefault(statType);
    }

    public void SetStat(EStatType statType, double value)
    {
        var stat = _stats.GetValueOrDefault(statType);
        stat.SetValue(value);
    }

    public void SetStatRate(EStatType statType, float rate)
    {
        var stat = _stats.GetValueOrDefault(statType);
        stat.SetRate(rate);
    }
}
