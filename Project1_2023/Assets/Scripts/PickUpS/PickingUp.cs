using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //when the player collides with the hitbox of the power up then the effect is activated
    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.tag == "Multiplier")
        {
            GameObject currentPickUp = collision.gameObject;
            Debug.Log("multiply");
            Destroy(currentPickUp);
            PickUpSpawn.spawnedPickUps.Remove(currentPickUp);
            //Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
            StartCoroutine(ScoreMultiplier.StartMultiply());
           


        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Multiplier")
        {
            GameObject currentPickUp = collision.gameObject;
            Debug.Log("multiply");
            Destroy(currentPickUp);
            PickUpSpawn.spawnedPickUps.Remove(currentPickUp);
            StartCoroutine(ScoreMultiplier.StartMultiply());



        }
    }
    //when the deleter trigger collids with the object it is deleted
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Multiplier")
        {
            GameObject currentPickUp = other.gameObject;
            //deletes the first instance of the tag within the list else it destroys all of them ahead of the player as well
            Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
            PickUpSpawn.spawnedPickUps.Remove(currentPickUp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
