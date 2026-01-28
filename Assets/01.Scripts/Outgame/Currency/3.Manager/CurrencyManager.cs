using System;
using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{ 
    private Currency _gold;
    public Currency Gold => _gold;

    private readonly ICurrencyRepository _repository = new LocalCurrencyRepository();
    
    public static event Action<Currency> OnChanged;
    
    protected override void OnInit()
    {
        _gold = _repository.Load();
    }

    public void Add(double amount)
    {
        _gold += amount;
    }

    public bool TrySpend(double amount)
    {
        if (_gold.Value < amount) return false;
        
        _gold -= amount;
        return true;
    }

    private void OnApplicationQuit()
    {
        _repository.Save(_gold);
    }
}
