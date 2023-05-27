using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectDeleter : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Awake()
    {
        
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Delete")
        {
           
                Destroy(this.gameObject);

            


            //Removes the destroyed object from the ObjectSpawners() spawnedObjects list;

        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
  
}
