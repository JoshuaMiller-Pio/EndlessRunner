using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    
    public int score;
   
    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "ScoreBox" )
        {
            if(ScoreMultiplier.multiplyOn == true)
            {
                score = score + 2;
            }
            else
            {
                score = score + 1;
                StopCoroutine(ScoreMultiplier.StartMultiply());
            }
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.Playerscore = score;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
