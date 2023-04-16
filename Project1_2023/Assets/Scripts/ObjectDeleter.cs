using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ObjectDeleter : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Awake()
    {
        
        //StartCoroutine(DestroyObject());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Delete")
        {
            Destroy(this.gameObject);
        }
    }
    /*public IEnumerator DestroyObject()
    {
        while (true)
        {
            int i = 0;
           /* for (int i = 0; i < spawner.obstaclesSpawned.Length; i++)
            {
                
            }*/
    /*  foreach (var obstacle in spawner.obstaclesSpawned)
      {
          if (spawner.obstaclesSpawned[i].transform.position.z < Player.transform.position.z)
          {
              GameObject myObstacle = spawner.obstaclesSpawned[i];
              Destroy(myObstacle);
              spawner.obstaclesSpawned[i] = null;
              for (int k = 0; k < spawner.obstaclesSpawned.Length; k++)
              {
                  if (spawner.obstaclesSpawned[k] = null)
                  {
                      GameObject temp = spawner.obstaclesSpawned[k + 1];
                      spawner.obstaclesSpawned[k] = temp;
                      k++;
                  }
              }
              i++;

          }
          else
          {
              yield return new WaitForSeconds(2);
          }
      }

      yield return new WaitForSeconds(2);
  }

}*/

    // Update is called once per frame
    void Update()
    {
        
    }
  
}
