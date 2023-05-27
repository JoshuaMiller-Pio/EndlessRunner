using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectSpawn : MonoBehaviour
{
    public GameObject[] obstacles;

    public GameObject Player;

    public GameObject[] spawnPositions = new GameObject[3];

    public Vector3 spawnPosition;
    void Start()
    {
       
        StartCoroutine(SpawnObject());
    }
    public IEnumerator SpawnObject()
    {
        int i = 0;
        while (true)
        {

            int objToSpwn = Random.Range(0, obstacles.Length);
            int spawnRate = Random.Range(2, 5);
            int spawnPos = Random.Range(0, 4);

            //Generates apropriate spawn position based on randomly selected lane and object prefab
            if (spawnPos == 1 && objToSpwn == 0 || spawnPos == 1 && objToSpwn == 3)
            {
                spawnPosition = spawnPositions[0].transform.position;
            }
            else if (spawnPos == 2 && objToSpwn == 0 || spawnPos == 2 && objToSpwn == 3)
            {
                spawnPosition = spawnPositions[1].transform.position;
            }
            else if (spawnPos == 3 && objToSpwn == 0 || spawnPos == 3 && objToSpwn == 3)
            {
                spawnPosition = spawnPositions[0].transform.position;
            }
            
            else
            {
                spawnPosition = spawnPositions[1].transform.position;
            }
            //Checks spawn location against the list of spawned objects position and generates a new spawn position if there would be a conflict (i.e spawning on or too close to an exhisting object)
           /* foreach (var obj in obstacles)
            {
                if (obj == null)
                {
                    int r = Random.Range(0, 4);
                    spawnPosition = spawnPositions[r].transform.position;
                    GameObject newSceneObject = Instantiate(obstacles[objToSpwn], spawnPosition, Quaternion.identity);
                    obstacles.Add(newSceneObject);
                }
                if (obj.transform.position.z == spawnPosition.z)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(40, 70));
                }
                if (obj.transform.position.z > spawnPosition.z && obj.transform.position.z < spawnPosition.z + 10)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(40, 70));
                }
                if (obj.transform.position.z < spawnPosition.z && obj.transform.position.z > spawnPosition.z - 10)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(40, 70));
                }
            }*/

            foreach (var obj in PickUpSpawn.spawnedPickUps)
            {
                if (obj == null)
                {
                    spawnPosition = new Vector3(0.63f, 0, (Player.transform.position.z + 40));
                    GameObject newSceneObject = Instantiate(PickUpSpawn.spawnedPickUps[objToSpwn], spawnPosition, Quaternion.identity);
                    PickUpSpawn.spawnedPickUps.Add(newSceneObject);
                }
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
            //Instantiates a new object at the final spawn position
            GameObject newObject = Instantiate(obstacles[objToSpwn], spawnPosition, Quaternion.identity);

            //Adds the spawned object to the list of spawned objects
           // spawnedObjects.Add(newObject);

            i++;
            yield return new WaitForSeconds(spawnRate);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
