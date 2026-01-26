using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Value ManualDamage; 
    public Value AutoDamage;
    public Value Gold;
    public Value Exp;

    public Value Level;
    
    private void Awake()
    {
        Instance = this;
        Level.SetValue(1);
    }

    public void GetReward(int gold, int exp)
    {
        Gold.AddValue(gold);
        Exp.AddValue(exp);
    }
}
