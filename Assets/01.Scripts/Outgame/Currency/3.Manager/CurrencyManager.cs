using System;
using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>, IReadOnlyValue
{ 
    private Currency _gold;
    public double Amount => _gold.Value;

    private readonly IRepository<Currency> _repository = new LocalCurrencyRepository();
    
    public event Action<double> OnChanged;
    
    protected override void OnInit()
    {
        _gold = _repository.Load();
    }

    private void Set(Currency gold)
    {
        _gold = gold;
        OnChanged?.Invoke(gold.Value);
    }
    
    public void Add(double amount)
    {
        Set(_gold + amount);
    }

    public bool TrySpend(double amount)
    {
        if (_gold.Value < amount) return false;
        
        Set(_gold - amount);
        return true;
    }

    private void OnApplicationQuit()
    {
        _repository.Save(_gold);
    }
}
