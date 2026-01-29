using System;
using UnityEngine;

[Serializable]
public class Stat : Value
{
    [SerializeField] private int _level = 1;
    public int Level => _level;

    public void LevelUp()
    {
        _level++;
        RefreshValue();
    }

    private void RefreshValue()
    {
        SetValue(GetValue(_level)); 
    }

    public double Cost => GetCost(_level);
    
    [Header("Base Config")]
    public double BaseValue = 10;
    public double BaseCost = 100;
    
    [Header("Growth Multipliers")]
    public float CostMultiplier = 1.15f;
    public float ValueMultiplier = 1.05f;

    public double GetCost(int level)
    {
        // 예: 100 * 1.5 ^ (level - 1)
        return BaseCost * Math.Pow(CostMultiplier, level - 1);
    }

    public double GetValue(int level)
    {
        // 예: 10 * 1.1 ^ (level - 1)
        return BaseValue * Math.Pow(ValueMultiplier, level - 1);
    }
}
