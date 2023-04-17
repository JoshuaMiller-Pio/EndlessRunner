using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
  
    [SerializeField]
    private TMPro.TextMeshProUGUI DeathText;
    private float playerscore;
    public string Player_Name;

    public float Playerscore   
    {
        get { return playerscore; }   
        set { playerscore = value; }
    }


    // Update is called once per frame
    void Update()
    {
      
    }
    private void Awake()
    {
        Debug.Log(playerscore + "nah");


    }
    public  void onQuitClicked()
    {
        Application.Quit();
    }
    public void onStartClicked()
    {
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void gameoverScore(int score )
    {
        DeathText = GameObject.FindGameObjectWithTag("output").GetComponent<TextMeshProUGUI>() ;
        DeathText.text = "Score: "+score;

    } 


}
