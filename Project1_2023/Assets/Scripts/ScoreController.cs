using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScoreController : MonoBehaviour
{
    
    public int score;
   
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ScoreBox")
        {
            score++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
