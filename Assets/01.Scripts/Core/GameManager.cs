using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Value ManualDamage; 
    public Value AutoDamage;
    public Value Gold;

    private void Awake()
    {
        Instance = this;
    }
}
