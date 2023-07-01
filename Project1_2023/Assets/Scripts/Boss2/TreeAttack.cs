using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAttack : MonoBehaviour
{
    public GameObject BulletSpawner, Bullet;
    public AudioSource TreeFire;
    float time = 5f;

    // Update is called once per frame
    void Update()
    {
  

        time -= Time.deltaTime;
        if (time <= 0)
        {
            time = 1f;
            FireAttack();
        }

    }

    void FireAttack()
    {
        Rigidbody fireballComp = Instantiate(Bullet, BulletSpawner.transform.position, transform.rotation).GetComponent<Rigidbody>();
        fireballComp.AddForce(0f, 0f, 35f, ForceMode.Impulse);
       // TreeFire.Play();
    }
}
