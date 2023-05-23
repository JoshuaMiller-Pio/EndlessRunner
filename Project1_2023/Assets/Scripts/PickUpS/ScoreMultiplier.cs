using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ScoreMultiplier : MonoBehaviour
{
    public static bool multiplyOn;
    public static GameObject multiplyUI;
   
    // Start is called before the first frame update
    void Awake()
    {
        multiplyOn = false;
        multiplyUI = GameObject.FindGameObjectWithTag("ImageX2");
        multiplyUI.SetActive(false);
    }
    public bool multiply()
    {
       
        return multiplyOn;
    }

    
    //
    public static IEnumerator StartMultiply()
    {
        
        multiplyOn = true;
        multiplyUI.SetActive(true);
        yield return new WaitForSeconds(5);
       
        multiplyOn = false;
        multiplyUI.SetActive(false);
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
