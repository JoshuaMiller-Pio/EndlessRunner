using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Multiplier")
        {
            StartCoroutine(ScoreMultiplier.StartMultiply());

            Destroy(other);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
