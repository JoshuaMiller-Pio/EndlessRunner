using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBroad : MonoBehaviour
{
    public GameObject Player;
    public TMP_Text ScoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = Player.GetComponent<ScoreController>().score;
        ScoreText.text = "Score: " + score;
    }
}
