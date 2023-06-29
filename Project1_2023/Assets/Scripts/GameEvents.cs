using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnScoreIncrease;

    public void ScoreIncrease()
    {
        
        if(OnScoreIncrease != null)
        {
            OnScoreIncrease();
        }
    }
    public event Action OnLevelScoreIncrease;

    public void LevelScoreIncrease()
    {
        if (OnLevelScoreIncrease != null)
        {
            OnLevelScoreIncrease();
        }
    }

    public event Action OnBossSpawn;

    public void BossSpawn()
    {
        if (OnBossSpawn != null)
        {
            OnBossSpawn();
        }
    }

}
