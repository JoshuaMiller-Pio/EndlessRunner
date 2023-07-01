using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    public UnityEngine.UI.Button[] Quit;
    public UnityEngine.UI.Button Start;
    public UnityEngine.UI.Button Submit;
    public TMPro.TMP_InputField submit;
    public UnityEngine.UI.Button Highscores;


    // Update is called once per frame
    void Update()

    {
        
    }
    //on awake the buttons are given a listener that will either call the quit or start method in the game managers
    void Awake()

    {

        Quit[0].onClick.AddListener(GameManager.Instance.onQuitClicked);
     
        Start.onClick.AddListener(GameManager.Instance.onStartClicked);
        if (submit != null)
        {
            Submit.onClick.AddListener(sendInfo);
        }
        if (Highscores != null)
        {
            Highscores.onClick.AddListener(GameManager.Instance.onHighScoreDisplay);
        }


    }
    void sendInfo()
    {
        GameManager.Instance.onSubmitClicked(submit);
    }
  

}
