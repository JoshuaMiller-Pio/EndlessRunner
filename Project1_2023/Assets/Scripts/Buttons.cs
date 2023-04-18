using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    public UnityEngine.UI.Button Quit;
    public UnityEngine.UI.Button Start;


    // Update is called once per frame
     void Update()
    {
        
    }
    void Awake()
    {

        Quit.onClick.AddListener(GameManager.Instance.onQuitClicked);
        Start.onClick.AddListener(GameManager.Instance.onStartClicked);
    }
    
    private void buttonPRess()
    {
       
    }


}
