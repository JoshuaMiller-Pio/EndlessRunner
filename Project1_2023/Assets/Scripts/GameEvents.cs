using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : Singleton<GameEvents>
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnScoreIncrease;

    public void ScoreIncrease()
    {
            
            OnScoreIncrease?.Invoke();
    }


    public event Action OnLevelScoreIncrease;

    public void LevelScoreIncrease()
    {
      
            OnLevelScoreIncrease?.Invoke();
        
    }


    public event Action OnBossSpawn;

    public void BossSpawn()
    {
        
            OnBossSpawn?.Invoke();
        
    }

}
