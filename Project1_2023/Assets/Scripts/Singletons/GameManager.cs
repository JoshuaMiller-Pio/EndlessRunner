using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
  
    [SerializeField]

    private TMPro.TextMeshProUGUI DeathText;
    public GameObject Boss,player;
    private float playerScore, levelScore, currentScore;
    public string Player_Name;
    public bool win = false, bossActive = false;

    //this Property allows other scripts to assign the player score to it
    public float Playerscore   
    {
        get { return playerScore; }   
        set { playerScore = value; }
    }
    public float Currentscore
    {
        get { return currentScore; }
        set { currentScore = value; }
    }
    public float LevelScore
    {
        get { return levelScore; }
        set { levelScore = value; }
    }

    private void Start()
    {
        GameEvents.current.OnBossSpawn += spawnBoss;
        GameEvents.current.OnLevelScoreIncrease += LevelscoreIncrease;
        Debug.Log("Scene");
        //limits frames to 60
        Application.targetFrameRate = 60;

    }


    // Update is called once per frame
    void Update()
    {
        //this checks what the current scene is
        scenecheck();        
    }

    void spawnBoss()
    {

        Boss.SetActive(true);
        Debug.Log("run");
    }

    private void FixedUpdate()
    {
        if (currentScore >= 1 && !bossActive)
        {
            bossActive = true;
            spawnBoss();
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
        playerScore = 0;
        currentScore = 0;
        Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
        Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
    }


    public void onHighScoreDisplay()
    {

    }
  public void onSubmitClicked(TMPro.TMP_InputField inputName)
    {

        Player_Name = inputName.text;
        DatabaseManager.Instance.WriteToFile(Player_Name, playerScore, levelScore);
    }

    //loads game over scene
    public void GameOver()
    {
        GameEvents.current.OnBossSpawn -= spawnBoss;
        bossActive = false;
        SceneManager.LoadScene(3);
        currentScore = 0;
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
        GameEvents.current.OnBossSpawn -= spawnBoss;

        if ((SceneManager.GetActiveScene().buildIndex == 1) && LevelScore <= 1)
        {
            SceneManager.LoadScene(2);

            currentScore = 0;


        }
        else
        {
            int random = Random.Range(1, 3);

            SceneManager.LoadScene(random);

        }

        GameEvents.current.OnBossSpawn += spawnBoss;

    }

    public void gameoverScore( )
    { 
        //assigns the deathtext tmpui component to the DeathScore_Txt box on the scene and updates the score that the player had
            DeathText = GameObject.Find("DeathScore_Txt").GetComponent<TextMeshProUGUI>();
            DeathText.text = $"score: {playerScore}";

    }

   void LevelscoreIncrease()
   {
        LevelScore++;

   }






}
