using System;
using UnityEngine;

[Serializable]
public class Stat : Value, IReadOnlyStat
{
    [SerializeField] private float _rate = 1f;
    
    public double FinalStat => _amount * _rate;
    
    public void SetRate(float rate)
    {
        _rate = rate;
    }
}
