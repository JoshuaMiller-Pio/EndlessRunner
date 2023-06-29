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
    public event Action OnLevelScoreIncrease;

    public void ScoreIncrease()
    {
        
        if(OnScoreIncrease != null)
        {
            OnScoreIncrease();
        }
    }
    public void LevelScoreIncrease()
    {
        if (OnLevelScoreIncrease != null)
        {
            OnLevelScoreIncrease();
        }
    }

}
