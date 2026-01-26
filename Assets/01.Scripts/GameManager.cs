using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int ManualDamage; 
    public int AutoDamage;
    public int Gold;

    private void Awake()
    {
        Instance = this;
    }
}
