using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Texture2D _cursor;

    [SerializeField] private GameData _data;
    public GameData Data => _data;
    
    public Level Level;
    public Stage Stage;
    public Fever Fever;
    
    public Value ManualDamage; 
    public Value AutoDamage;
    
    public Value GoldReward;
    public Value ExpReward;

    public float DamageFactor;

    public HashSet<Slime> Slimes = new();
    
    protected override void OnInit()
    {
        Level = _data.Level;
        Stage = _data.Stage;
        Fever = _data.Fever; 
        ManualDamage = _data.ManualDamage; 
        AutoDamage = _data.AutoDamage; 
        GoldReward = _data.GoldReward; 
        ExpReward = _data.ExpReward;
        
        Cursor.SetCursor(_cursor, Vector2.zero, CursorMode.Auto);
        Level.OnLevelUp += LevelUp;
    }

    private void OnDestroy()
    {
        Level.OnLevelUp -= LevelUp;
    }

    private void OnApplicationQuit()
    {
        FileIO.Save(_data);
    }

    public void GetReward()
    {
        CurrencyManager.Instance.Gold.AddValue(GoldReward.Amount);
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
        Stage.AddKill();
        Fever.AddGauge();
    }
}
