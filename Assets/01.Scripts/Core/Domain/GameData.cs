using System;
using UnityEngine;

[Serializable]
public class GameData : MonoBehaviour
{
    public Level Level;
    public Stage Stage;
    public Fever Fever;
    
    public Value ManualDamage; 
    public Value AutoDamage;
    
    public Value GoldReward;
    public Value ExpReward;

    public Value Gold;

    public string GetSummary()
    {
        return string.Empty;
    }
}
