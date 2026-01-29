using System;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePresenter : MonoBehaviour
{
    private Dictionary<EStatType, Stat> _stats = new();

    public void Initialize(ReadOnlySpan<Stat> stats)
    {
        foreach (var stat in stats)
        {
            //_stats.Add(stat.Type, stat);
        }
    }
}
