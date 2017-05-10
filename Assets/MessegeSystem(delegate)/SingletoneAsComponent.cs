﻿using UnityEngine;
using System.Collections;
//Оптимизация Unity - Profiler.Страница 67,68,70.
public class SingletonAsComponent<T> : MonoBehaviour where T : SingletonAsComponent<T>
{

    private static T __Instance;

    protected static SingletonAsComponent<T> _Instance
    {
        get
        {
            if (!__Instance)
            {
                T[] managers = GameObject.FindObjectsOfType(typeof(T)) as T[];
                if (managers != null)
                {
                    if (managers.Length == 1)
                    {
                        __Instance = managers[0];
                        return __Instance;
                    }
                    else if (managers.Length > 1)
                    {
                        Debug.LogError("You have more than one " + typeof(T).Name + " in the scene. You only need 1, it's a singleton!");
                        for (int i = 0; i < managers.Length; ++i)
                        {
                            T manager = managers[i];
                            Destroy(manager.gameObject);
                        }
                    }
                }

                GameObject go = new GameObject(typeof(T).Name, typeof(T));
                __Instance = go.GetComponent<T>();
                DontDestroyOnLoad(__Instance.gameObject);
            }
            return __Instance;
        }
        set
        {
            __Instance = value as T;
        }
    }

    void Awake()
    {
        if (ShouldBeSetToDontDestroyOnLoadDuringAwake())
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    // can be overridden to ensure that if we start the Scene with this object present
    // then it wont be destroyed later
    // This can be dangerous if we load a second scene that also contains this object!
    protected virtual bool ShouldBeSetToDontDestroyOnLoadDuringAwake()
    {
        return false;
    }

    private bool _alive = true;
    public static bool IsAlive
    {
        get
        {
            if (__Instance == null)
                return false;
            return __Instance._alive;
        }
    }

    void OnDestroy()
    {
        _alive = false;
    }

    void OnApplicationQuit()
    {
        _alive = false;
    }
}
// Optimization Unity page 70
/*public class SomeClass : MonoBehaviour
{
    void OnDestroy()
    {
        if (MySingltonComponent.IsAlive)
            MySingltonComponent.Instance.SomeMethod();
    }
}*/
