using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugiaEntrance : MonoBehaviour
{
    private Quaternion target ;
    public GameObject mainBody;
    public GameObject player;
    private Rigidbody Main_comp;
    // Start is called before the first frame update
    void  Awake()
    {
        
        target = new Quaternion();
        target.SetEulerAngles(0,0,0);
        Main_comp = mainBody.GetComponent<Rigidbody>();
        StartCoroutine(EntranceMove());
       StartCoroutine(EntranceRotation());
        


    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator EntranceMove()
    {
        Vector3 targetPosition = new Vector3(mainBody.transform.position.x, mainBody.transform.position.y, player.transform.position.z + 23.19f);
        float time = 0;
        while (time < 1)
        {
            mainBody.transform.position = Vector3.Lerp(mainBody.transform.position, targetPosition, time / 10f);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = target;
        LugiaController.BaseMove();


    }

   
    IEnumerator EntranceRotation()
    {
        float time = 0;
        while (time<10)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, target, time / 10f);
            time += Time.deltaTime;
                yield return null;
           
        }
        transform.rotation = target;
    }
}
