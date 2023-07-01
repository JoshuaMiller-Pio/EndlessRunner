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

    private void Start()
    {

        gameObject.SetActive(false);

    }

    #region Damage
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FireBall" || other.gameObject.tag == "Obstacle")
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
        GameEvents.current.LevelScoreIncrease();
        GameManager.Instance.levelWin();
        Destroy(gameObject);
    }


    
  
    #endregion



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
           GameManager.Instance.bossActive = false;

    }
}
