using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPawnerMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 10f;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * speed;
    }
}
