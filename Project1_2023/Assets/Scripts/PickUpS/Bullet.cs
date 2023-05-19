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
            ObjectSpawner.spawnedObjects.Remove(other.gameObject);
            Destroy(other.gameObject);
            Destroy(this.gameObject);

            //Removes the destroyed object from the ObjectSpawners() spawnedObjects list;

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
