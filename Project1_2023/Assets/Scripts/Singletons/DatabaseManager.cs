
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class DatabaseManager : Singleton<DatabaseManager>
{
    
    // Start is called before the first frame update
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

        if (!System.IO.File.Exists(path))
        {
            using (StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine($"{Name}#{score}#{bossesBeat}");
            }
        }
        //writes to the file
        else
        {
            using (StreamWriter writer = System.IO.File.AppendText(path))
            {

                writer.WriteLine($"{Name}#{score}#{bossesBeat}");
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
            TMPro.TextMeshProUGUI lable_name;
            lable_name = GameObject.Find("name_Display").GetComponent<TMPro.TextMeshProUGUI>();
            List<String> scoreDetails = new List<String>();
          //while not end of file it populates the list with details
            while (!reader.EndOfStream)
            {

                scoreDetails.Add(reader.ReadLine());
            }
            lable_name.text = scoreDetails[0];
          
        }
    }
    

        
    
    
}
