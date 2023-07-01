using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : Boss_Super
{
    static Rigidbody RigComp;
    float timer = 2.5f;
    static float health = 10;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    private TreeController() : base(health)
    {

    }
    // Start is called before the first frame update
    void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, (GameObject.FindGameObjectWithTag("PlayerChar").transform.position.z - 38f));
        RigComp = GetComponent<Rigidbody>();

    }
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            LaneDecider();
            timer = Random.Range(3,5);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            health--;
            if (health <= 0)
            {
                GameManager.Instance.levelWin();
            }
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
        left = new Vector3(-5.3f, transform.position.y, transform.position.z + 9.9f);
        middle = new Vector3(0.85f, transform.position.y, transform.position.z + 9.9f);
        right = new Vector3(6.6f, transform.position.y, transform.position.z + 9.9f);

        Vector3[] lanesPick = new Vector3[] { left, middle, right };

        StartCoroutine(LerpLane(lanesPick[lane]));

    }
    IEnumerator LerpLane(Vector3 targetLane)
    {
        Vector3 startPos = transform.position;

        float time = 0;
        while (time < 1f)
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
