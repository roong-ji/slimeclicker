using System;
using UnityEngine;

[Serializable]
public class Stat : Value
{
    [SerializeField] private float _rate;
    public float Rate => _rate;

    public void SetRate(float rate)
    {
        _rate = rate;
    }
}
