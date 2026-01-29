using UnityEngine;

public class LocalCurrencyRepository : IRepository<Currency>
{
    public void Save(Currency currency)
    {
        CurrencyData data = new(currency);
        FileIO.Save(data);
    }

    public Currency Load()
    {
        CurrencyData data = new();
        FileIO.Load(data);

        return data.Currency;
    }
}

[System.Serializable]
public class CurrencyData
{
    [SerializeField] private Currency _currency;
    public Currency Currency => _currency;

    public CurrencyData(Currency currency = default)
    {
        _currency = currency;
    }
}