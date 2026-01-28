using System;
using UnityEngine;

[Serializable]
public class Fever
{
    [Header("Settings")]
    public int Threshold = 20;
    public float Duration = 5f;

    [Header("Status")]
    public int Gauge = 0;
    public bool IsFever = false;

    public event Action OnFeverStarted;
    public event Action OnFeverEnded;

    public void AddGauge()
    {
        if (IsFever) return;

        Gauge++;

        if (Gauge < Threshold) return;
        StartFever();
    }

    public void StartFever()
    {
        IsFever = true;
        Gauge = 0;
        OnFeverStarted?.Invoke();
    }

    public void EndFever()
    {
        IsFever = false;
        OnFeverEnded?.Invoke();
    }
}
