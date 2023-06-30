using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
  
    [SerializeField]

    private TMPro.TextMeshProUGUI DeathText;
    public GameObject Boss,player;
    private float playerscore, levelScore;
    int levelRestart;
    public string Player_Name;
    public bool win = false, bossActive = false;

    //this Property allows other scripts to assign the player score to it
    public float Playerscore   
    {
        get { return playerscore; }   
        set { playerscore = value; }
    }
    public float LevelScore
    {
        get { return levelScore; }
        set { levelScore = value; }
    }

    private void Start()
    {
        GameEvents.current.OnBossSpawn += spawnBoss;
        GameEvents.current.OnLevelScoreIncrease -= LevelscoreIncrease;

    }

    // Update is called once per frame
    void Update()
    {
        //limits frames to 60
        Application.targetFrameRate = 60;
        //this checks what the current scene is
        scenecheck();


    }

    void spawnBoss()
    {
            Boss.SetActive(true);
            
    }
    private void FixedUpdate()
    {
        if (playerscore >= 1 && !bossActive)
        {
          bossActive = true;
            GameEvents.current.BossSpawn();
        }
    }


    //once called it closes the application
    public  void onQuitClicked()
    { 
        Application.Quit();
    }
    //Once called it it clears the spawnedpickups and spawnedobjects list and loads the 2nd scene
    public void onStartClicked()
    {
        bossActive = false;
        SceneManager.LoadScene(1);
        playerscore = 0;
       levelRestart =  1;
        Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
        Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
    }

    public void onRestartClicked()
    {
        bossActive = false;
        SceneManager.LoadScene(levelRestart);
        playerscore = 0;
        Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
        Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
    }

    //loads game over scene
    public void GameOver()
    {
        bossActive = false;
        SceneManager.LoadScene(3);

    }

       //if is current scene is game over it calls the game over score
    public void scenecheck()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            gameoverScore();
        }
    }

    public void levelWin()
    {
        if((SceneManager.GetActiveScene().buildIndex == 3) && LevelScore <= 1)
        {
            SceneManager.LoadScene(2);
            levelRestart = 2;


        }
        else
        {
            SceneManager.LoadScene(Random.Range(1, 3));
            levelRestart = SceneManager.GetActiveScene().buildIndex;

        }
    }

    public void gameoverScore( )
    { 
        //assigns the deathtext tmpui component to the DeathScore_Txt box on the scene and updates the score that the player had
            DeathText = GameObject.Find("DeathScore_Txt").GetComponent<TextMeshProUGUI>();
            DeathText.text = $"score: {playerscore}";

    }

   void LevelscoreIncrease()
    {
        LevelScore++;

    }




}
