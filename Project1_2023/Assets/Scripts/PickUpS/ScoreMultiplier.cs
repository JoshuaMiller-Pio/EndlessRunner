using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ScoreMultiplier : MonoBehaviour
{
    public static bool multiplyOn;
    public static GameObject multiplyUI;
    public static bool startFade;
    public static bool multiplyOnScreen;


    // Start is called before the first frame update
    void Awake()
    {
        startFade = false;
        multiplyOn = false;
        multiplyUI = GameObject.FindGameObjectWithTag("ImageX2");
        multiplyUI.SetActive(false);
      multiplyOnScreen = false;
    }
    public bool multiply()
    {
       
        return multiplyOn;
    }

    
    //
    public static IEnumerator StartMultiply(TMPro.TextMeshProUGUI timers)
    {
        multiplyOn = true;
        multiplyUI.SetActive(true);
        multiplyOnScreen = true;
        int j = 10;


        while(j > 0)
        {
          
            
           
     
            timers.text = $"{j}";
            yield return new WaitForSeconds(1);
            
            j--;
            
        }
        
       
        multiplyOn = false;
        multiplyUI.SetActive(false);
        yield return null;
    }

    public static void UIOn()
    {
        
    }

    public static void UIOff()
    {
        
    }
   /*public static IEnumerator NormalImage()
    {

        yield return new WaitForSeconds(6);
        startFade = true;
    }*/

    /*public static IEnumerator ImageFade()
    {
        int i = 4;
        while(i > 0)
        {
            if(multiplyUI.active == true)
            { 
                multiplyUI.SetActive(false);
            }
            if (multiplyUI.active == false)
            {
                multiplyUI.SetActive(true);
            }
            yield return new WaitForSeconds(1);
            i--;
        }
        multiplyUI.SetActive(false);
        startFade =false;
    }*/
    
    // Update is called once per frame
    void Update()
    {
       /* if(startFade == true)
        {
            StartCoroutine(ImageFade());
        }*/
    }
}
