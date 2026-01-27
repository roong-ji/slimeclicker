using System;
using UnityEngine;

[Serializable]
public class Value
{
    [SerializeField] private double _amount;
    public double Amount => _amount;
    
    public event Action<double> OnValueChanged;

    public void SetValue(double amount)
    {
        _amount = amount;
        OnValueChanged?.Invoke(_amount);
    }

    public void AddValue(double amount)
    {
        SetValue(_amount + amount);
    }

    public void SubValue(double amount)
    {
        SetValue(_amount - amount);
    }
}
