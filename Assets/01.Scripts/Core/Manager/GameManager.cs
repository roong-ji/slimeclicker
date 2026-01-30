using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Texture2D _cursor;
    
    public Level Level;
    public Stage Stage;
    public Fever Fever;

    public float DamageFactor;

    public HashSet<Slime> Slimes = new();
    
    protected override void OnInit()
    {
        Cursor.SetCursor(_cursor, Vector2.zero, CursorMode.Auto);
        Level.OnLevelUp += LevelUp;
    }

    private void OnDestroy()
    {
        Level.OnLevelUp -= LevelUp;
    }

    public void GetReward()
    {
        CurrencyManager.Instance.Add(StatManager.Instance.GetStat(EStatType.GoldReward).Amount);
        Level.AddExp(StatManager.Instance.GetStat(EStatType.ExpReward).Amount);
    }

    private void LevelUp(int level)
    {
        //ManualDamage.MulValue(DamageFactor);
        //AutoDamage.MulValue(DamageFactor);
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
