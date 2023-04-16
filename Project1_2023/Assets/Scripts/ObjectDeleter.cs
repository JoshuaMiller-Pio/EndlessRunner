using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectDeleter : MonoBehaviour
{
    public GameObject Player;
   
    
    // Start is called before the first frame update
    void Awake()
    {
        StartCoroutine(DestroyObject());
    }
    public IEnumerator DestroyObject()
    {
        while (true)
        {
            for (int i = 0; i < ObjectSpawner.obstaclesSpawned.Length; i++)
            {
                if (ObjectSpawner.obstaclesSpawned[i].transform.position.z < Player.transform.position.z)
                {
                    Destroy(ObjectSpawner.obstaclesSpawned[i]);
                }
            }
            
            yield return new WaitForSeconds(5);
        }
        
    }
    public void GetArray()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
  
}
