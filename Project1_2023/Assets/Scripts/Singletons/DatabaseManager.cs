
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class DatabaseManager : Singleton<DatabaseManager>
{

    List<String> scoreDetails = new List<String>();
    String path = Directory.GetCurrentDirectory() + "/Highscore.txt";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void WriteToFile(string Name,float score,float bossesBeat)
    {
        //checks if the file exists if not it creates the file and writes to it
        Debug.Log("sheeeeeee");

        if (!System.IO.File.Exists(path))
        {
            using (StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine($"{Name}#{bossesBeat}#{score}");
            }
        }
        //writes to the file
        else
        {
            using (StreamWriter writer = System.IO.File.AppendText(path))
            {


                writer.WriteLine($"{Name}#{bossesBeat}#{score}");
            }
        }

        Debug.Log(path);

    }
    public void ReadFromFile()
    {
        //checks if the file exists if not it creates the file
        if (!System.IO.File.Exists(path))
        {
            TMPro.TextMeshProUGUI lable_name;
            lable_name = GameObject.Find("name_Display").GetComponent<TMPro.TextMeshProUGUI>();
            lable_name.text = "created";
            using (StreamWriter writer = System.IO.File.CreateText(path))
            {

            }
        }

        //if file is found, it reads
        using (StreamReader reader = new StreamReader(path))
        {
          
          //while not end of file it populates the list with details
            while (!reader.EndOfStream)
            {

                scoreDetails.Add(reader.ReadLine());
            }
                Displayer();
        }
    }
    
    void Displayer()
    {
        //get all the fields
        TMPro.TextMeshProUGUI lable_name, lable_bossKill, lable_totalScore;
        lable_name = GameObject.Find("name_Display").GetComponent<TMPro.TextMeshProUGUI>();
        lable_bossKill = GameObject.Find("boss_Display").GetComponent<TMPro.TextMeshProUGUI>();
        lable_totalScore = GameObject.Find("score_Display").GetComponent<TMPro.TextMeshProUGUI>();
        TMPro.TextMeshProUGUI[] infoArray = new TMPro.TextMeshProUGUI[]{ lable_name, lable_bossKill, lable_totalScore };

        for (int i = 0; i < scoreDetails.Count; i++)
        {
           String[] info = scoreDetails[i].Split('#');
            for (int j = 0; j < 3; j++)
            {
                infoArray[j].text += (info[j] + "\n");

            }
        }



    }
        
    
    
}
