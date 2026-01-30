using System;
using UnityEngine;

[Serializable]
public class Stat : Value
{
    [SerializeField] private double _stat;
    [SerializeField] private float _rate = 1f;

    public void SetBaseValue(double stat)
    {
        _stat = stat;
        SetValue(_stat * _rate);
    }
    
    public void SetRate(float rate)
    {
        _rate = rate;
        SetValue(_stat * _rate);
    }
}
