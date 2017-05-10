using System.Collections;
using System;
using UnityEngine;
using System.Runtime.InteropServices;
// Страница 314 Мульти.
public class TestPlugin : MonoBehaviour {
    private static TestPlugin _instance;

    public static void Initialize()
    {
        if (_instance != null)
        {
            Debug.Log("TestPlugin instance was found. Already initialized");
            return;
        }
        Debug.Log("TestPlugin instance not found. Initializing...");
        GameObject owner = new GameObject("TestPlugin_instance");
        _instance = owner.AddComponent<TestPlugin>();
        DontDestroyOnLoad(_instance);
    }
    #region iOS ¬ Тег, определяющий раздел кода; сам по себе он ничего не делает.
    [DllImport("__Internal")]
    private static extern float _TestNumber(); // Ссылка на функцию в коде iOS.
    [DllImport("__Internal")]
    private static extern string _TestString(string test);
    #endregion iOS
    public static float TestNumber()
    {
        float val = 0f;
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        val = _TestNumber(); //¬ Вызывается в случае платформы IPhonePlayer.
        return val;
    }
    public static string TestString(string test)
    {
        string val = "";
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        val = _TestString(test);
        return val;
    }
}

