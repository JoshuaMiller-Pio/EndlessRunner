using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    public UnityEngine.UI.Button[] Quit = null;
    public UnityEngine.UI.Button Start;
    public UnityEngine.UI.Button Submit = null;
    public UnityEngine.UI.Button Menu = null;
    public TMPro.TMP_InputField submit_text;
    public UnityEngine.UI.Button Highscores;


    // Update is called once per frame
    void Update()

    {
        
    }
    //on awake the buttons are given a listener that will either call the quit or start method in the game managers
    void Awake()

    {
        if (Menu != null)
        {
            Menu.onClick.AddListener(GameManager.Instance.onMenuClicked);
        }


        Start.onClick.AddListener(GameManager.Instance.onStartClicked);

        if (Submit != null)
        {
            Submit.onClick.AddListener(sendInfo);
        }
        if (Highscores != null)
        {
            Highscores.onClick.AddListener(GameManager.Instance.onHighScoreDisplay);
        }
        if (Quit.Length != null)
        {
        Quit[0].onClick.AddListener(GameManager.Instance.onQuitClicked);

        }


    }
    void sendInfo()
    {
        GameManager.Instance.onSubmitClicked(submit_text);
    }
  

}
