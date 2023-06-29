using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Super : MonoBehaviour
{
    float _health;

    public Boss_Super(float Health)
    {
        _health = Health;
    }

    private void Awake()
    {
        GameEvents.current.OnScoreIncrease += increaseLevelScore;

    }

    #region Damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireBall")
        {
            onDamageTaken();
            Destroy(other.gameObject);
        }
    }

    private void onDamageTaken()
    {
        _health -= 1;
        if (_health <= 0)
        {

            onDeath();
        }
    }


    private void onDeath()
    {
        Debug.Log(GameManager.Instance.LevelScore);

        GameManager.Instance.levelWin();
        Destroy(gameObject);
    }
    void increaseLevelScore()
    {
        GameManager.Instance.LevelScore += 1;
    }
    private void OnDestroy()
    {
        
;        GameEvents.current.OnScoreIncrease -= increaseLevelScore;

    }

  
    #endregion



    // Update is called once per frame
    void Update()
    {
        
    }
}
