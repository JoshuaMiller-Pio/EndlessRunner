using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject Player;
    public static bool shielded;
    public static GameObject playersShield; 
    public static GameObject shieldUI;

    void Awake()
    {
        shielded = false;
        playersShield = GameObject.FindGameObjectWithTag("PlayerShield");
        shieldUI = GameObject.FindGameObjectWithTag("ImageShield");
        shieldUI.SetActive(false);
        playersShield.SetActive(false);

    }
    public static bool isShielded()
    {

        return shielded;
    }

    public static IEnumerator StartShield(TMPro.TextMeshProUGUI timers)
    { 
        shielded = true;
        playersShield.SetActive(true);
        shieldUI.SetActive(true);
        int j = 15;
        while (j > 0)
        {




            timers.text = $"{j}";
            yield return new WaitForSeconds(1);
            j--;

        }
        

        shielded = false;
        playersShield.SetActive(false );
        shieldUI .SetActive(false );
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
