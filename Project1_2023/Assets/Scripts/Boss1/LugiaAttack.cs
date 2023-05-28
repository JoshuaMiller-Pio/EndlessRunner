using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LugiaAttack : MonoBehaviour
{
    public GameObject FireballSpawner, FireBall;
    public AudioSource Fire;
    float time= 5f;
 

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            FireAttack();
            time = Random.Range(2,6);
        }
    }
   void FireAttack()
   {
        Rigidbody fireballComp = Instantiate(FireBall, FireballSpawner.transform.position, transform.rotation).GetComponent<Rigidbody>();
        fireballComp.AddForce(0, -4f, -10f, ForceMode.Impulse);
        Fire.Play();
    }
}
