using System;
using UnityEngine;

[Serializable]
public class GameData
{
    public Level Level;
    public Stage Stage;
    
    public Stat ManualDamage; 
    public Stat AutoDamage;
    
    public Stat GoldReward;
    public Stat ExpReward;

    public Stat Gold;
    
    public string GetSummary()
    {
        return string.Empty;
    }
}
