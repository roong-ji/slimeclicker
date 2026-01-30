using UnityEngine;
using System.IO;

public class LocalCurrencyRepository : IRepository<Currency>
{
    private readonly string _saveFilePath = Path.Combine(Application.persistentDataPath, SaveFileName);
    private const string SaveFileName = "Save.dat";
    
    public void Save(Currency currency)
    {
        var saveData = new CurrencySaveData(currency);
        FileIO.Save(saveData, _saveFilePath);
    }

    public Currency Load()
    {
        var saveData = new CurrencySaveData();
        FileIO.Load(saveData, _saveFilePath);

        return saveData.Currency;
    }
}

[System.Serializable]
public class CurrencySaveData
{
    [SerializeField] private Currency _currency;
    public Currency Currency => _currency;

    public CurrencySaveData(Currency currency = default)
    {
        _currency = currency;
    }
}