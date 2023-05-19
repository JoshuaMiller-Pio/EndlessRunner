using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody _rigComp;
    public GameObject Player;
    public static bool strapped;
    public static GameObject playersShield;
    // Start is called before the first frame update
    void Start()
    {
        strapped = false;
        _rigComp = GetComponent<Rigidbody>();
        _rigComp.AddForce(transform.forward * -5000, ForceMode.Force);
    }

    public static bool isStrapped()
    {
        return strapped;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
