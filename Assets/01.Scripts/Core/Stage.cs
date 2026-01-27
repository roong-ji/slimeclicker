using System;
using UnityEngine;

[Serializable]
public class Stage
{
    [Header("Stage Info")]
    public int CurrentStage = 1;
    public int KillCount = 0;
    public int KillsRequiredPerStage = 10;

    [Header("Fever Info")]
    public int FeverKillCount = 0;
    public int FeverThreshold = 5;
    public bool IsFeverActive = false;

    [Header("Balance")]
    public float DifficultyFactor = 1.2f;

    public event Action OnFeverStarted;

    public void AddKill()
    {
        KillCount++;
        
        // 피버 게이지 상승 (피버 중이 아닐 때만)
        if (!IsFeverActive)
        {
            FeverKillCount++;
            if (FeverKillCount >= FeverThreshold)
            {
                IsFeverActive = true;
                OnFeverStarted?.Invoke();
            }
        }

        // 스테이지 진행 체크
        if (KillCount >= KillsRequiredPerStage)
        {
            NextStage();
        }
    }

    private void NextStage()
    {
        CurrentStage++;
        KillCount = 0;
    }

    // 현재 스테이지에 따른 수치 계산 공식
    public double GetScaledValue(double baseValue)
    {
        return baseValue * Math.Pow(DifficultyFactor, CurrentStage - 1);
    }
}
