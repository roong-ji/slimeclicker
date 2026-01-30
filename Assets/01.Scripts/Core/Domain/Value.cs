using System;
using UnityEngine;

[Serializable]
public class Value : IReadOnlyValue
{
    [SerializeField] protected double _amount;
    public double Amount => _amount;
    
    public event Action<double> OnChanged;

    public void SetValue(double amount)
    {
        _amount = amount;
        OnChanged?.Invoke(_amount);
    }

    public void AddValue(double amount)
    {
        SetValue(_amount + amount);
    }

    public void SubValue(double amount)
    {
        SetValue(_amount - amount);
    }

    public void MulValue(double amount)
    {
        SetValue(_amount * amount);
    }
}