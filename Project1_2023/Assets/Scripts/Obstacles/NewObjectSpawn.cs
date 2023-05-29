using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewObjectSpawn : MonoBehaviour
{
    public GameObject[] obstacles;

    public GameObject Player;

    public GameObject[] spawnPositions = new GameObject[3];

    public Vector3 spawnPosition;

    //public static GameObject[] spawnedObjects = new GameObject[10] ;
    void Start()
    {
       
        StartCoroutine(SpawnObject());
    }
    public IEnumerator SpawnObject()
    {
        int i = 1;
        while (true)
        {

            int objToSpwn = Random.Range(0, obstacles.Length);
            int spawnRate = Random.Range(2, 5);
            int spawnPos = Random.Range(0, 4);

            //Generates apropriate spawn position based on randomly selected lane and object prefab
            if (spawnPos == 0 && objToSpwn == 0 || spawnPos == 0 && objToSpwn == 2)
            {
                spawnPosition = spawnPositions[0].transform.position;
            }
            else if (spawnPos == 1 && objToSpwn == 0 || spawnPos == 1 && objToSpwn == 2)
            {
                spawnPosition = spawnPositions[1].transform.position;
            }
            else if (spawnPos == 2 && objToSpwn == 0 || spawnPos == 2 && objToSpwn == 2)
            {
                spawnPosition = spawnPositions[0].transform.position;
            }
            
            else
            {
                spawnPosition = spawnPositions[1].transform.position;
            }
          
            GameObject newObject = Instantiate(obstacles[objToSpwn], spawnPosition, Quaternion.identity);
          

            i++;
            yield return new WaitForSeconds(spawnRate);

        }
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}
