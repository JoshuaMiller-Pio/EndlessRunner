
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    
    public static int score;
   
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.OnScoreIncrease += increaseScore;
        score = 0;
        
    }

    //if the delete trigger exits the object the score counter goes up


     void increaseScore()
     {
          //if player has a multiplier on then score is doubled
          if (ScoreMultiplier.multiplyOn == true)
          {

            GameManager.Instance.Playerscore += 2;
            GameManager.Instance.Currentscore += 2;

        }
        else
          {
             GameManager.Instance.Playerscore += 1;
             GameManager.Instance.Currentscore += 1;

          }

     }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy()
    {
        GameEvents.current.OnScoreIncrease -= increaseScore;

    }
}
