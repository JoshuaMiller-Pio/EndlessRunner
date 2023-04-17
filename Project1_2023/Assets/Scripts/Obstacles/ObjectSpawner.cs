using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstacles ;
   // public  GameObject[] obstaclesSpawned = new GameObject[10];
    public GameObject Player;
    public enum lanes { First, Second, Third};
    public Vector3 spawnPosition;
    
    // Update is called once per frame
    private void Awake()
    {
      
        StartCoroutine(SpawnObject());
       
    }
    void Update()
    {
        
    }

    public  IEnumerator SpawnObject()
    {
        int i = 0;
        while (true) 
        {
            
            int objToSpwn = Random.Range(0, obstacles.Length);
            int spawnRate = Random.Range(0,5);
            int lane = Random.Range(0, 4);
            if (lane == 1 && objToSpwn == 0)
            {
                spawnPosition = new Vector3(-5.17f, 0.25f, (Player.transform.position.z + 40));
            }
            else if (lane == 2 && objToSpwn == 0)
            {
                spawnPosition = new Vector3(0.81f, 0.25f, (Player.transform.position.z + 40));
            }
            else if (lane == 3 && objToSpwn == 0)
            {
                spawnPosition = new Vector3(6.58f, 0.25f, (Player.transform.position.z + 40));
            }
            else
            {
                spawnPosition = new Vector3(0.63f, 0, (Player.transform.position.z + 40));
            }
            GameObject newObject = Instantiate(obstacles[objToSpwn], spawnPosition, Quaternion.identity);
           
            
           // obstaclesSpawned[i] = newObject;
            i++;
            yield return new WaitForSeconds(spawnRate);

        }
    }
    

}
