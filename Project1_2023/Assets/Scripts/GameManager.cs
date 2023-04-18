using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
  
    [SerializeField]

    private TMPro.TextMeshProUGUI DeathText;
    private float playerscore;
    public string Player_Name;

    //this Property allows other scripts to assign the player score to it
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
        //this checks what the current scene is
        scenecheck();

    }
    private void Awake()
    {


    }
    //once called it closes the application
    public  void onQuitClicked()
    {

        Application.Quit();
    }
    //Once called it it clears the spawnedpickups and spawnedobjects list and loads the 2nd scene
    public void onStartClicked()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(1);
        foreach (var obj in PickUpSpawn.spawnedPickUps)
        {
            PickUpSpawn.spawnedPickUps.Remove(obj);
        }
        Destroy(GameObject.FindGameObjectWithTag("Multiplier"));

        foreach (var obj in ObjectSpawner.spawnedObjects)
        {
            ObjectSpawner.spawnedObjects.Remove(obj);
        }
        Destroy(GameObject.FindGameObjectWithTag("Obstacle"));
       
        
        

    }
    //loads game over scene
    public void GameOver()
    {
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
    public void gameoverScore( )
    { 
        //assigns the deathtext tmpui component to the DeathScore_Txt box on the scene and updates the score that the player had
            DeathText = GameObject.Find("DeathScore_Txt").GetComponent<TextMeshProUGUI>();
            DeathText.text = $"score: {playerscore}";

    }
  
    public static void rePlay()
    {
        
    }



}
