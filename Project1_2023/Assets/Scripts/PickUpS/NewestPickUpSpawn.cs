using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewestPickUpSpawn : MonoBehaviour
{
    public GameObject[] pickUps;

    public GameObject Player;

    public GameObject[] spawnPositions = new GameObject[3];

    public Vector3 spawnPosition;
    void Start()
    {

        StartCoroutine(SpawnObject());
    }
    public IEnumerator SpawnObject()
    {
       
        while (true)
        {

            int objToSpwn = Random.Range(0, 3);
            int spawnRate = Random.Range(2, 5);
            int spawnPos = Random.Range(0, 3);

            //Generates apropriate spawn position based on randomly selected lane and object prefab
            if (spawnPos == 0)
            {
                spawnPosition = spawnPositions[0].transform.position;
            }
            else if (spawnPos == 1)
            {
                spawnPosition = spawnPositions[1].transform.position;
            }
            else if (spawnPos == 2)
            {
                spawnPosition = spawnPositions[2].transform.position;
            }

            

            //Instantiates a new object at the final spawn position
            GameObject newObject = Instantiate(pickUps[objToSpwn], spawnPosition, Quaternion.identity);

            
            
            yield return new WaitForSeconds(spawnRate);

        }
        // Start is called before the first frame update

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
