using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{ 
    private readonly Value _gold = new();
    public Value Gold => _gold;

    private readonly ICurrencyRepository _repository = new LocalCurrencyRepository();
    
    protected override void OnInit()
    {
        _repository.Load(_gold);
    }

    private void OnApplicationQuit()
    {
        _repository.Save(_gold);
    }
}
