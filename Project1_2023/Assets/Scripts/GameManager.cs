using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
  
    [SerializeField]

    private TMPro.TextMeshProUGUI DeathText;
    public GameObject Boss,player;
    private float playerscore, levelScore;
    public string Player_Name;
    private bool bossActive = false;
    public bool win = false;

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
        GameEvents.current.OnLevelScoreIncrease -= scoreIncrease;

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
  
        Destroy(GameObject.FindGameObjectWithTag("Multiplier"));

   
        Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
       
        
        

    }
    //loads game over scene
    public void GameOver()
    {
        bossActive = false;
        SceneManager.LoadScene(2);

    }

       //if is current scene is game over it calls the game over score
    public void scenecheck()
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            gameoverScore();
        }
    }

    public void levelWin()
    {
        bossActive = false;
        
        Canvas uiCanvas, vicCanvas;
        Camera Vicam, maincam;
        for (int i = 0; i < GameObject.FindObjectsOfType<Canvas>(true).Length; i++)
        {
            if (GameObject.FindObjectsOfType<Canvas>(true)[i].name == "VictoryCanvas")
            {
                 vicCanvas = GameObject.FindObjectsOfType<Canvas>(true)[i];
                vicCanvas.gameObject.SetActive(true);
                for (int j = 0; j < GameObject.FindObjectsOfType<GameObject>().Length; j++)
                {
                     if (GameObject.FindObjectsOfType<GameObject>(true)[i].name == "NewObjectSpawner")
                     {
                        GameObject SpawnerDisable = GameObject.FindObjectsOfType<GameObject>(true)[j];
                        vicCanvas.gameObject.SetActive(false);

                     }

                }

            }
            else
            {
                 uiCanvas = GameObject.FindObjectsOfType<Canvas>(true)[i];
                uiCanvas.gameObject.SetActive(false);

            }
        }


        for (int i = 0; i < GameObject.FindObjectsOfType<Camera>(true).Length; i++)
        {
            if (GameObject.FindObjectsOfType<Camera>(true)[i].name == "VicCam")
            {
                Vicam = GameObject.FindObjectsOfType<Camera>(true)[i];
                Vicam.gameObject.SetActive(true);
            }
            else
            {
                maincam = GameObject.FindObjectsOfType<Camera>(true)[i];
                maincam.gameObject.SetActive(false);
            }
            
       
        }
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
        win = true;
    }

    public void gameoverScore( )
    { 
        //assigns the deathtext tmpui component to the DeathScore_Txt box on the scene and updates the score that the player had
            DeathText = GameObject.Find("DeathScore_Txt").GetComponent<TextMeshProUGUI>();
            DeathText.text = $"score: {playerscore}";

    }

   void scoreIncrease()
    {
        LevelScore++;

    }




}
