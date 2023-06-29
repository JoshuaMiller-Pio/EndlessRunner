using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LugiaController : Boss_Super
{
   static Rigidbody RigComp;
    float timer = 2.5f;
    static float health = 1;


    private LugiaController() : base(health)
    {

    }
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, (GameObject.FindGameObjectWithTag("PlayerChar").transform.position.z - 3.78f) );
        RigComp = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            LaneDecider();
            timer = 5f;
        }
    }





    #region Movement
    public static void BaseMove()
    {
        RigComp.velocity = new Vector3(0, 0, 9.9f);
    }
    
    
    void LaneDecider()
    {

        int lane = Random.Range(0, 3);
        Vector3 left, middle, right;
        left = new Vector3(-32.5f, transform.position.y, transform.position.z +9.9f);
        middle = new Vector3(-26.7f, transform.position.y, transform.position.z + 9.9f);
        right = new Vector3(-20.9f, transform.position.y, transform.position.z + 9.9f);

        Vector3[] lanesPick = new Vector3[] {left, middle, right };

        StartCoroutine(LerpLane(lanesPick[lane]));

    }
    IEnumerator LerpLane(Vector3 targetLane)
    {
        Vector3 startPos = transform.position;
    
        float time = 0;
        while(time <1f)
        {
            transform.position = Vector3.Lerp(startPos, targetLane, time / 1f);

            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetLane;
        BaseMove();

    }
 
    #endregion
  
}
