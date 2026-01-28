using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{ 
    private Value _gold;
    public Value Gold => _gold;

    private void Start()
    {
        _gold = GameManager.Instance.Data.Gold;
    }
}
