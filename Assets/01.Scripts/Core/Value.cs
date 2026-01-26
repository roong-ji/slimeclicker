using System;
using UnityEngine;

[System.Serializable]
public class Value
{
    [SerializeField] private int _amount;
    public int Amount => _amount;

    public event Action<int> OnValueChanged;

    public void SetValue(int amount)
    {
        if (_amount == amount) return;
        _amount = amount;
        OnValueChanged?.Invoke(_amount);
    }

    public void AddValue(int amount)
    {
        SetValue(_amount + amount);
    }
}
