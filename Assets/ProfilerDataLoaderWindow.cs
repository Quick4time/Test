using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class PRofilerDataLoaderWindow : EditorWindow {
    static List<string> s_cachedFilePath;
    static int s_chosenIndex = -1;

    [MenuItem("Window/ProfilerDataLoader")]
    static void Init()
    {
        PRofilerDataLoaderWindow window = (PRofilerDataLoaderWindow)EditorWindow.GetWindow(typeof(PRofilerDataLoaderWindow));
        window.Show();

        ReadProfilerDataFiles();
    }

    static void ReadProfilerDataFiles()
    {
        UnityEngine.Profiling.Profiler.logFile = "";

        string[] filePath = Directory.GetFiles(Application.persistentDataPath, "profilerLog*");
        s_cachedFilePath = new List<string>();
        Regex test = new Regex(".data$");

        for (int i = 0; i < filePath.Length; i++)
        {
            string thisPath = filePath[i];
            Match match = test.Match(thisPath);

            if(!match.Success)
            {
                Debug.Log("Found file: " + thisPath);
                s_cachedFilePath.Add(thisPath);
            }
        }
        s_chosenIndex = -1;
    }
    
    void OnGUI()
    {
        if (GUILayout.Button("Find Files"))
        {
            ReadProfilerDataFiles();
        }
        if (s_cachedFilePath == null)
            return;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Files");
        EditorGUILayout.BeginHorizontal();

        GUIStyle defaultStyle = new GUIStyle(GUI.skin.button);
        defaultStyle.fixedWidth = 40f;

        GUIStyle highlightStyle = new GUIStyle(defaultStyle);
        highlightStyle.normal.textColor = Color.red;

        for (int i = 0; i < s_cachedFilePath.Count; i++)
        {
            if (i % 5 == 0)
            {
                EditorGUILayout.EndHorizontal();
                EditorGUILayout.BeginHorizontal();
            }
            GUIStyle thisStyle = null;

            if (s_chosenIndex == i)
            {
                thisStyle = highlightStyle;
            }
            else
            {
                thisStyle = defaultStyle;
            }

            if (GUILayout.Button("" + i, thisStyle))
            {
                UnityEngine.Profiling.Profiler.AddFramesFromFile(s_cachedFilePath[i]);
                s_chosenIndex = i;
            }
        }
            
            EditorGUILayout.EndHorizontal();
        }
    }
