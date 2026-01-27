using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Level Level;
    
    public Value ManualDamage; 
    public Value AutoDamage;
    public Value Gold;
    
    public Value GoldReward;
    public Value ExpReward;

    public float DamageFactor;

    public HashSet<Slime> Slimes = new();
    
    private void Awake()
    {
        Instance = this;
        Level.OnLevelUp += LevelUp;
    }

    private void OnDestroy()
    {
        Level.OnLevelUp -= LevelUp;
    }

    public void GetReward()
    {
        Gold.AddValue(GoldReward.Amount);
        Level.AddExp(ExpReward.Amount);
    }

    private void LevelUp(int level)
    {
        ManualDamage.MulValue(DamageFactor);
        AutoDamage.MulValue(DamageFactor);
    }
    
    public void RegisterSlime(Slime slime)
    {
        Slimes.Add(slime);
    }

    public void UnregisterSlime(Slime slime)
    {
        Slimes.Remove(slime);
    }
}
