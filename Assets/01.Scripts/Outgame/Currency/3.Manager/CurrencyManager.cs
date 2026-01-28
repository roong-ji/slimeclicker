using UnityEngine;

public class CurrencyManager : Singleton<CurrencyManager>
{ 
    private readonly Value _gold = new();
    public Value Gold => _gold;

    private readonly LocalCurrencyRepository _repository = new();
    
    protected override void OnInit()
    {
        _repository.Load(_gold);
    }

    private void OnApplicationQuit()
    {
        _repository.Save(_gold);
    }
}
