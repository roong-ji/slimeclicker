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
    }
}
