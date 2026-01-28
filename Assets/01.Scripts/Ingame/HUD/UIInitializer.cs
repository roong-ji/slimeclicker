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
        if (gm == null)
        {
            Debug.LogError("GameManager를 찾을 수 없습니다!");
            return;
        }

        _goldPresenter.Initialize(cm);
        _manualDmgPresenter.Initialize(gm.ManualDamage);
        _autoDmgPresenter.Initialize(gm.AutoDamage);
        _goldRewardPresenter.Initialize(gm.GoldReward);
        _expRewardPresenter.Initialize(gm.ExpReward);
        _levelPresenter.Initialize(gm.Level);
    }
}
