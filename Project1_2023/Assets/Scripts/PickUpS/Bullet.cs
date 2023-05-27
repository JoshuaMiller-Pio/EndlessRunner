using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody _rigComp;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        _rigComp = GetComponent<Rigidbody>();
        _rigComp.AddForce(transform.forward * 5000, ForceMode.Force);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Obstacle")
        {
           
            
            
            Destroy(this.gameObject);
            if (ScoreMultiplier.multiplyOn == true)
            {
                ScoreController.score = ScoreController.score + 2;
            }
            else if (ScoreMultiplier.multiplyOn == false)
            {
                ScoreController.score = ScoreController.score + 1;
            }
           
            Destroy(other.gameObject);


           

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
