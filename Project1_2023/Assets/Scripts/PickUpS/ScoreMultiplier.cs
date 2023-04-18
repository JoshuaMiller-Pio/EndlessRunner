using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class ScoreMultiplier : MonoBehaviour
{
    public static bool multiplyOn;
    // Start is called before the first frame update
    void Awake()
    {
        multiplyOn = false;
    }
    public bool multiply()
    {
       
        return multiplyOn;
    }

    
    //
    public static IEnumerator StartMultiply()
    {
        
        multiplyOn = true;
      
        yield return new WaitForSeconds(5);
       
        multiplyOn = false;
        
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
