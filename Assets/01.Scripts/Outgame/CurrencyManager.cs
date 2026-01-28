using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{ 
    [SerializeField] private Value _gold;
    public Value Gold => _gold;
    
    
}
