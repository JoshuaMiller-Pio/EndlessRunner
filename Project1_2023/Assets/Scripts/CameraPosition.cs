using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public GameObject Player;
    Vector3 CameraCurrentPosition;
    public GameObject Boss;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss)
        {

            CameraCurrentPosition = new Vector3(0.95f, 9, Boss.transform.position.z - 3);
          gameObject.transform.position = CameraCurrentPosition;
        }
    }
}
