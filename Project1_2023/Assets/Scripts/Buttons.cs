using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Buttons : MonoBehaviour
{
    public UnityEngine.UI.Button Quit;
    public UnityEngine.UI.Button Start;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        Quit.onClick.AddListener(GameManager.Instance.onQuitClicked);
        Start.onClick.AddListener(GameManager.Instance.onStartClicked);

    }
}
