using System;
using UnityEngine;

[Serializable]
public class Level
{
    [Header("Status")]
    [SerializeField] private int _level = 1;
    [SerializeField] private double _exp = 0;
    public int Value => _level;
    public double Exp => _exp;
    
    public Action<int> OnLevelUp;
    public Action<double, double> OnExpChanged;

    [Header("Settings")]
    [SerializeField] private double BaseMaxExp = 25;
    [SerializeField] private float ExpMultiplier = 1.5f;

    public double MaxExp => BaseMaxExp * Mathf.Pow(ExpMultiplier, _level - 1);

    public void AddExp(double amount)
    {
        _exp += amount;
        
        while (_exp >= MaxExp)
        {
            _exp -= MaxExp;
            _level++;
            OnLevelUp?.Invoke(_level);
        }
        
        OnExpChanged?.Invoke(_exp, MaxExp);
    }
}
