using UnityEngine;

public class LocalCurrencyRepository : ICurrencyRepository
{
    public void Save<T>(T data)
    {
        FileIO.Save(data);
    }

    public void Load<T>(T data)
    {
        FileIO.Load(data);
    }
}
