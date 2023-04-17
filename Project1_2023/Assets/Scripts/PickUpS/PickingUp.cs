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
        if (gameObject.tag == "PlayerChar" && other.tag == "Multiplier")
        {
            Debug.Log("multiply");
            StartCoroutine(ScoreMultiplier.StartMultiply());

            Destroy(GameObject.FindGameObjectWithTag("Multiplier"));
           
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
