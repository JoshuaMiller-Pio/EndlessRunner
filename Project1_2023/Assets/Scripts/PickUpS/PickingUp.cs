using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    public AudioSource DoubleSound;
    public TMPro.TextMeshProUGUI shield_timers, multiplyer_timers;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //when the player collides with the hitbox of the power up then the effect is activated
    private void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.tag == "Multiplier")
        {
            GameObject currentPickUp = other.gameObject;
            
            PickUpSpawn.spawnedPickUps.Remove(currentPickUp);
            DoubleSound.Play();
            Destroy(currentPickUp);
            //Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
            StartCoroutine(ScoreMultiplier.StartMultiply(multiplyer_timers));
           // StartCoroutine(ScoreMultiplier.NormalImage());
        }

        if (other.gameObject.tag == "ShieldPickUp")
        {
            GameObject currentPickUp = other.gameObject;
       
            PickUpSpawn.spawnedPickUps.Remove(currentPickUp);
            Destroy(currentPickUp);

            //Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
            StartCoroutine(Shield.StartShield(shield_timers));
        }

        if (other.gameObject.tag == "GunPickUp")
        {
            GameObject currentPickUp = other.gameObject;
        
            PickUpSpawn.spawnedPickUps.Remove(currentPickUp);
            Destroy(currentPickUp);

            //Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
            GunPickUp.GotGun();
        }
    }

 
    //when the deleter trigger collids with the object it is deleted
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Multiplier")
        {
            GameObject currentPickUp = other.gameObject;
            //deletes the first instance of the tag within the list else it destroys all of them ahead of the player as well
            PickUpSpawn.spawnedPickUps.Remove(currentPickUp);
            Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
            
        }


    }*/

    // Update is called once per frame
    void Update()
    {
        
    }
}
