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
        //limits frames to 60
        Application.targetFrameRate = 60;
        scenecheck();

    }
    private void Awake()
    {


    }
    public  void onQuitClicked()
    {
        Debug.Log("quit");

        Application.Quit();
    }
    public void onStartClicked()
    {
        Debug.Log("restart");
        PickUpSpawn.spawnedPickUps.Clear();
        ObjectSpawner.spawnedObjects.Clear();
        SceneManager.LoadScene(1);
    }
    public void GameOver()
    {
        SceneManager.LoadScene(2);

    }

       
    public void scenecheck()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            gameoverScore();
        }
    }
    public void gameoverScore( )
    {

        //does it from scene 1 thats why
       
        
            DeathText = GameObject.Find("DeathScore_Txt").GetComponent<TextMeshProUGUI>();
            DeathText.text = $"score: {playerscore}";
        
        

    }
    IEnumerator deathScore(int score)
    {
       
        yield return null; 
    }



}
