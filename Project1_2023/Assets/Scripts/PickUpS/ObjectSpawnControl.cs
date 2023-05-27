using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ShieldPickUp" || collision.gameObject.tag == "Multiplier" || collision.gameObject.tag == "GunPickUp")
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z + 3);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
