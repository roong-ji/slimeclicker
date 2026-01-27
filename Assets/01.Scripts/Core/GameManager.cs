using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Value ManualDamage; 
    public Value AutoDamage;
    public Value Gold;
    public Value Exp;

    public Value Level;
    
    public Value GoldReward;
    public Value ExpReward;
    
    private void Awake()
    {
        Instance = this;
        Level.SetValue(1);
    }

    public void GetReward()
    {
        Gold.AddValue(GoldReward.Amount);
        Exp.AddValue(ExpReward.Amount);
    }
}
