using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private Button Start;
    [SerializeField]
    private Button Quit;

   
    // Update is called once per frame
    void Update()
    {
      
    }
    public  void onQuitClicked()
    {
        Debug.Log("quit");
        Application.Quit();
    }
    public void onStartClicked()
    {
        Debug.Log("start");
    }

}
