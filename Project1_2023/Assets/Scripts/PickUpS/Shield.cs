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

    public static IEnumerator StartShield()
    {

        shielded = true;
        playersShield.SetActive(true);
        shieldUI.SetActive(true);
        yield return new WaitForSeconds(15);

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
