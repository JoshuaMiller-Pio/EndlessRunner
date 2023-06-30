using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrees : MonoBehaviour
{
    float dist = 128.8f*3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "PlayerChar")
        {
            gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, (gameObject.transform.position.z+ dist));
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
