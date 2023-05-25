using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LugiaEntrance : MonoBehaviour
{
    public  Transform transform_comp;
    // Start is called before the first frame update
    void  Start()
    {
        transform_comp = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        EntranceRotation();

    }

    void EntranceRotation()
    {
        transform_comp.Rotate(0,0,0, Space.Self);
    }
}
