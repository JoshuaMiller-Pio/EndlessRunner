using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawn : MonoBehaviour
{
    public GameObject[] pickUps;
    // public  GameObject[] obstaclesSpawned = new GameObject[10];
    public GameObject Player;
    public enum lanes { First, Second, Third };
    public Vector3 spawnPosition;
    public static List<GameObject> spawnedPickUps = new List<GameObject>();
    // Update is called once per frame
    private void Awake()
    {
        spawnedPickUps = new List<GameObject>();
        StartCoroutine(SpawnPickUp());

    }
    void Update()
    {

    }

    public IEnumerator SpawnPickUp()
    {
        int i = 0;
        while (true)
        {

            int objToSpwn = Random.Range(0, pickUps.Length);

            int spawnRate = Random.Range(5, 10);

            int lane = Random.Range(0, 4);

            //Generates apropriate spawn position based on randomly selected lane and object prefab
            if (lane == 1)
            {
                spawnPosition = new Vector3(-5.17f, 0.37f, (Player.transform.position.z + 40));
            }
            if (lane == 2)
            {
                spawnPosition = new Vector3(0.81f, 0.37f, (Player.transform.position.z + 40));
            }
            if (lane == 3)
            {
                spawnPosition = new Vector3(6.58f, 0.37f, (Player.transform.position.z + 40));
            }

            //Checks spawn location against the list of spawned objects position and generates a new spawn position if there would be a conflict (i.e spawning on or too close to an exhisting object)
            foreach (var obj in ObjectSpawner.spawnedObjects)
            {
                if (obj.transform.position.z == spawnPosition.z)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(15, 25));
                }
                if (obj.transform.position.z > spawnPosition.z && obj.transform.position.z < spawnPosition.z + 10)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(15, 25));
                }
                if (obj.transform.position.z < spawnPosition.z && obj.transform.position.z > spawnPosition.z - 10)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(15,25));
                }
            }

            //Checks spawn location against the list of spawned objects position and generates a new spawn position if there would be a conflict (i.e spawning on or too close to an exhisting object)
            foreach (var obj in spawnedPickUps)
            {
                if (obj.transform.position.z == spawnPosition.z)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(15, 25));
                }
                if (obj.transform.position.z > spawnPosition.z && obj.transform.position.z < spawnPosition.z + 10)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(15, 25));
                }
                if (obj.transform.position.z < spawnPosition.z && obj.transform.position.z > spawnPosition.z - 10)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(15, 25));
                }
            }

            GameObject newObject = Instantiate(pickUps[objToSpwn], spawnPosition, Quaternion.identity);

            spawnedPickUps.Add(newObject);

            i++;
            yield return new WaitForSeconds(spawnRate);

        }
    }


}
