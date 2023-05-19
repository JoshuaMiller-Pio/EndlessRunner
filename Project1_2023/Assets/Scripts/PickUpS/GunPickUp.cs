using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public GameObject Player;
    public static bool strapped;
    public static int ammo;
    // Start is called before the first frame update
    void Start()
    {
        ammo = 0;
        strapped = false;
    }
    public static bool isStrapped()
    {
        return strapped;
    }

    public static void GotGun()
    {
        strapped =true;
        ammo = 3;
    }
    public static void Shoot()
    {
        ammo--;
        if (ammo <= 0)
        {
            strapped = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
