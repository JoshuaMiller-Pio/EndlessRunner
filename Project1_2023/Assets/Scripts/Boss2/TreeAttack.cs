using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeAttack : MonoBehaviour
{
    public GameObject BulletSpawner, Bullet;
    public AudioSource TreeFire;
    float time = 5f;
    public bool reloading;

    // Update is called once per frame
    void Update()
    {
        /*if (!reloading)
        {
            FireAttack();
            reloading = true;
            StartCoroutine(Reload());
        }*/
        time -= Time.deltaTime;
        if (time <= 0)
        {
            FireAttack();
            time = 5;
        }

    }

    IEnumerator Reload()
    {
        reloading = false;
        yield return new WaitForSeconds(Random.Range(3,5));
        
    }
    void FireAttack()
    {
        Rigidbody fireballComp = Instantiate(Bullet, BulletSpawner.transform.position, transform.rotation).GetComponent<Rigidbody>();
        fireballComp.AddForce(0f, 0f, 10f, ForceMode.Impulse);
        TreeFire.Play();
    }
}
