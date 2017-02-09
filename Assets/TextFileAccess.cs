using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Лучше использовать статичную загрузку так как меньше нагрузки на комп. Первая.
/// </summary>
// Страница 227. Доступ к внешним тхт файлам.
public class TextFileAccess : MonoBehaviour {
    // Для внутренних файлов.
    public TextAsset TextData = null;

    // Динамическая загрузка текстовых ресурсов.
    public static string LoadTextFromFile(string Filename)
    {
        if (!File.Exists(Filename)) return string.Empty;
        return File.ReadAllText(Filename);
    }

    public static string[] LoadTextAsLine (string Filename)
    {
        if (!File.Exists(Filename)) return null;
        return File.ReadAllLines(Filename);
    }
	// Use this for initialization
	void Start () {      
        Debug.Log(LoadTextFromFile(@"C:\fuckit\TestText.txt"));
        Debug.Log(LoadTextAsLine(@"C:\fuckit\TestText.txt"));
        Debug.Log(TextData.text);
    }
}
