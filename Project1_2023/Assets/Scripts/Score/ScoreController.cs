using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    
    public static int score;
   
    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        
    }

    //if the delete trigger exits the object the score counter goes up
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "ScoreBox" )
        {
            //if player has a multiplier on then score is doubled
            if(ScoreMultiplier.multiplyOn == true)
            {
                score +=  2;
                GameManager.Instance.Playerscore += 2;

            }
            else
            {
                score += 1;
                GameManager.Instance.Playerscore += 1;

            }
            
        }
    }

    //once the player collides with an object the final score is sent to player 
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
