using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private Button Start;
    [SerializeField]
    private Button Quit;
    [SerializeField]
    private TextMeshProUGUI DeathText;
    

   
    // Update is called once per frame
    void Update()
    {
      
    }
    private void Awake()
    {
        Quit.onClick.AddListener(onQuitClicked);
        Start.onClick.AddListener(onStartClicked);
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
        Debug.Log(score);
        DeathText.text = $"Score: {score}";
    }

}
