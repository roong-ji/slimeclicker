using UnityEngine;

public class LocalCurrencyRepository : ICurrencyRepository<Value>
{
    public void Save(Value data)
    {
        FileIO.Save(data);
    }

    public void Load(Value data)
    {
        FileIO.Load(data);
    }
}
