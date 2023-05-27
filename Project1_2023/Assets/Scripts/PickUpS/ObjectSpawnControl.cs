using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ShieldPickUp" || other.gameObject.tag == "Multiplier" || other.gameObject.tag == "GunPickUp")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 3);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
}
