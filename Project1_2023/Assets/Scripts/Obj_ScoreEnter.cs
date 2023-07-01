
using UnityEngine;

public class Obj_ScoreEnter : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "PlayerChar")
        {

            GameEvents.current.ScoreIncrease();
        }
    }
}
