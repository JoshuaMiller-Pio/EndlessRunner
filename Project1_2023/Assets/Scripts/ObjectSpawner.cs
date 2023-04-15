using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    public GameObject Player;
    public enum lanes { First, Second, Third};
    
    // Update is called once per frame
    void Update()
    {
        
    }

   public  IEnumerator SpawnObject()
    {
        int spawnRate = Random.Range(2, 8);
        int lane = Random.Range(0, 4);
        if (lane == 1)
        {
            Vector3 spawnPosition = new Vector3(-5.5f, 0.68f, (Player.transform.position.z + 20));
        }
        if (lane == 2)
        {
            Vector3 spawnPosition = new Vector3(0.75f, 0.68f, (Player.transform.position.z + 20));
        }
        if (lane == 3)
        {
            Vector3 spawnPosition = new Vector3(6.15f, 0.68f, (Player.transform.position.z + 20));
        }
        yield return new WaitForSeconds(spawnRate);
    }
}
