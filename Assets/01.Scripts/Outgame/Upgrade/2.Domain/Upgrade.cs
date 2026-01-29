using System;
using UnityEngine;

[Serializable]
public class Upgrade
{
    private UpgradeData _data;

    public Upgrade(UpgradeData data, int level = 1)
    {
        if (data.MaxLevel < 0) throw new ArgumentException($"최대 레벨은 0보다 커야 합니다: {data.MaxLevel}");
        if (data.BaseCost <= 0) throw new ArgumentException($"기본 비용은 0 이상이어야 합니다: {data.BaseCost}");
        if (data.BaseValue <= 0) throw new ArgumentException($"기본 값은 0 이상이어야 합니다: {data.BaseValue}");
        if (data.CostMultiplier < 0) throw new ArgumentException($"비용 증가량은 0보다 커야 합니다: {data.CostMultiplier}");
        if (data.ValueMultiplier < 0) throw new ArgumentException($"비용 증가량은 0보다 커야 합니다: {data.ValueMultiplier}");

        _data = data;
        Level = level;
    }
    
    public int Level { get; private set; }
    public double Cost => _data.BaseCost * Math.Pow(_data.CostMultiplier, Level - 1);
    public double Value => _data.BaseValue * Math.Pow(_data.ValueMultiplier, Level - 1);
    public bool IsMaxLevel => Level >= _data.MaxLevel;
    
    public event Action<double> OnChanged;

    public bool TryLevelUp()
    {
        if (IsMaxLevel) return false;
        Level++;
        OnChanged?.Invoke(Cost);
        return true;
    }
}