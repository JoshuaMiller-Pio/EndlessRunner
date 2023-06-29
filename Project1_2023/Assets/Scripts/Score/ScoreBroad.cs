using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBroad : MonoBehaviour
{
    public  GameObject Player;
    public  TMP_Text ScoreText;
    public  int score;
    public int ammoCount;
    public TMP_Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    // Update is called once per frame
    void Update()
    {
        score = ScoreController.score;
        ScoreText.text = "Score: " + score;
        ammoCount = GunPickUp.ammo;
        ammoText.text = "Ammo: " + ammoCount.ToString();
    }
}
