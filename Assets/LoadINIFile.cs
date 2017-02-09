using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

// страница 230. Загрузка INI файлов.
public class LoadINIFile : MonoBehaviour
{
    public static Dictionary<string, string> ReadINIFile (string Filename)
    {
        if (!File.Exists(Filename)) return null;

        Dictionary<string, string> INIFile = new Dictionary<string, string>();

        using (StreamReader SR = new StreamReader(Filename))
        {
            string Line;
            while (!string.IsNullOrEmpty(Line = SR.ReadLine()))
            {
                Line.Trim();
                string[] Parts = Line.Split(new char[] { '=' });
                INIFile.Add(Parts[0].Trim(), Parts[1].Trim());
            }
        }
        return INIFile;
    }

    Dictionary<string, string> DB = ReadINIFile(@"C:\Users\lapan_000\Desktop\Test_INI.ini");

    void Start()
    {
        foreach (KeyValuePair<string,string> Entry in DB)
        {
            Debug.Log("Key: " + Entry.Key + " Value: " + Entry.Value);
        }
    }
}
