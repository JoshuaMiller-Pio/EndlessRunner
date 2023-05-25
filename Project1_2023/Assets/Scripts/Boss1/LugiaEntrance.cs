using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugiaEntrance : MonoBehaviour
{
    private Transform EntranceRotate;
    // Start is called before the first frame update
    void  Awake()
    {
        EntranceRotate = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        EntranceRotation();

    }

    void EntranceRotation()
    {
        EntranceRotate.rotation = Quaternion.Lerp(0,0,0);
    }
}
