using UnityEngine;

public class UIInitializer : MonoBehaviour
{
    [Header("UI 연결")]
    [SerializeField] private ValuePresenter _goldPresenter;
    [SerializeField] private ValuePresenter _manualDmgPresenter;
    [SerializeField] private ValuePresenter _autoDmgPresenter;
    [SerializeField] private ValuePresenter _goldRewardPresenter;
    [SerializeField] private ValuePresenter _expRewardPresenter;
    [SerializeField] private LevelPresenter _levelPresenter;
    
    private void Start()
    {
        InitializeAll();
    }

    private void InitializeAll()
    {
        var gm = GameManager.Instance;
        var cm = CurrencyManager.Instance;
        var sm = StatManager.Instance;
        if (gm == null)
        {
            Debug.LogError("GameManager를 찾을 수 없습니다!");
            return;
        }

        _goldPresenter.Initialize(cm);
        _manualDmgPresenter.Initialize(sm.GetStat(EStatType.ManualDamage));
        _autoDmgPresenter.Initialize(sm.GetStat(EStatType.AutoDamage));
        _goldRewardPresenter.Initialize(sm.GetStat(EStatType.GoldReward));
        _expRewardPresenter.Initialize(sm.GetStat(EStatType.ExpReward));
        _levelPresenter.Initialize(gm.Level);
    }
}
