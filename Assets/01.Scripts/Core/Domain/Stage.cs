using System;
using UnityEngine;

[Serializable]
public class Stage
{
    [Header("Stage Info")]
    public int CurrentStage = 1;
    public int KillCount = 0;
    public int KillsRequiredPerStage = 10; 

    [Header("Balance")]
    public float HealthRate = 1;
    public float DifficultyFactor = 1.5f;
    public float StageFactor = 1.2f;
    
    public void AddKill()
    {
        KillCount++;

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
        HealthRate *= DifficultyFactor;
        KillsRequiredPerStage = (int)(KillsRequiredPerStage * StageFactor);
    }
}
