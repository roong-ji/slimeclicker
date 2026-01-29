using UnityEngine;

public class UIInitializer : MonoBehaviour
{
    [Header("UI 연결")]
    [SerializeField] private ValueView goldView;
    [SerializeField] private ValueView manualDmgView;
    [SerializeField] private ValueView autoDmgView;
    [SerializeField] private ValueView goldRewardView;
    [SerializeField] private ValueView expRewardView;
    [SerializeField] private LevelView levelView;
    
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

        goldView.Initialize(cm);
        manualDmgView.Initialize(sm.GetStat(EStatType.ManualDamage));
        autoDmgView.Initialize(sm.GetStat(EStatType.AutoDamage));
        goldRewardView.Initialize(sm.GetStat(EStatType.GoldReward));
        expRewardView.Initialize(sm.GetStat(EStatType.ExpReward));
        levelView.Initialize(gm.Level);
    }
}
