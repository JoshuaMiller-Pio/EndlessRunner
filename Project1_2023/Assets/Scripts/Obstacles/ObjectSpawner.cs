using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] obstacles ;
   
    public GameObject Player;
    public enum lanes { First, Second, Third};
    public Vector3 spawnPosition;
    public static List<GameObject> spawnedObjects = new List<GameObject>();

    // Update is called once per frame
    public void Awake()
    {
        GameManager.rePlay();
        spawnedObjects = new List<GameObject>();
        StartCoroutine(SpawnObject());
       
    }
    
    void Update()
    {
        
    }

    public IEnumerator SpawnObject()
    {
        int i = 0;
        while (true) 
        {
            
            int objToSpwn = Random.Range(0, obstacles.Length);
            int spawnRate = Random.Range(0,3);
            int lane = Random.Range(0, 4);

            //Generates apropriate spawn position based on randomly selected lane and object prefab
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
            else if (lane == 1 && objToSpwn == 3)
            {
                spawnPosition = new Vector3(-5.17f, 1.57f, (Player.transform.position.z + 40));
            }
            else if (lane == 2 && objToSpwn == 3)
            {
                spawnPosition = new Vector3(0.81f, 1.57f, (Player.transform.position.z + 40));
            }
            else if (lane == 3 && objToSpwn == 3)
            {
                spawnPosition = new Vector3(6.58f, 1.57f, (Player.transform.position.z + 40));
            }
            else
            {
                spawnPosition = new Vector3(0.63f, 0, (Player.transform.position.z + 40));
            }
            //Checks spawn location against the list of spawned objects position and generates a new spawn position if there would be a conflict (i.e spawning on or too close to an exhisting object)
            foreach (var obj in spawnedObjects) 
            {
                if(obj == null)
                {
                    spawnPosition = new Vector3(0.63f, 0, (Player.transform.position.z + 40));
                    GameObject newSceneObject = Instantiate(obstacles[objToSpwn], spawnPosition, Quaternion.identity);
                    spawnedObjects.Add(newSceneObject);
                }
                if (obj.transform.position.z == spawnPosition.z)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(40,70));
                }
                if(obj.transform.position.z > spawnPosition.z && obj.transform.position.z < spawnPosition.z + 10) 
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(40, 70));
                }
                if (obj.transform.position.z < spawnPosition.z && obj.transform.position.z > spawnPosition.z - 10)
                {
                    spawnPosition.z = spawnPosition.z + (Player.transform.position.z + Random.Range(40, 70));
                }
            }

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
            spawnedObjects.Add( newObject );
            
            i++;
            yield return new WaitForSeconds(spawnRate);

        }
    }
    

}
