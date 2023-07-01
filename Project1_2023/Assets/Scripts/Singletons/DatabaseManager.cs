using OpenCover.Framework.Model;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System;
using UnityEngine;
using Unity.VisualScripting;

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
        if (!System.IO.File.Exists(path))
        {
            using (StreamWriter writer = System.IO.File.CreateText(path))
            {
                writer.WriteLine($"{Name}#{score}#{bossesBeat}");
            }
        }
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
        if (!System.IO.File.Exists(path))
        {
            using (StreamWriter writer = System.IO.File.CreateText(path))
            {

            }
        }
        using (StreamReader reader = new StreamReader(path))
        {
            reader.ReadLine();
        }
    }
    

        
    
    
}
