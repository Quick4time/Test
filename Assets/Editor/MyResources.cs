
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MyResources : ScriptableObject
{/*
    [System.Serializable]
    private class ResourceInfo
    {
        public string path;
        public Object asset;
    }

    [SerializeField]
    private List<ResourceInfo> resources;

    static private MyResources instance;

    static private MyResources Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Resources.Load("MyResources") as MyResources;
            }
            return instance;
        }
    }

    static public Object Load(string path)
    {
        var record = Instance.resources.FirstOrDefault(resource => resource.path == path);
        return record == null ? null : record.asset;
    }

    static public T Load<T>(string path) where T : Object
    {
        return Load(path) as T;
    }
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Assets/Create/MyResources")]
    static void Create()
    {
        var asset = ScriptableObject.CreateInstance<MyResources>();
        var path = "Resources/MyResources.asset";
        UnityEditor.AssetDatabase.CreateAsset(asset, path);
        UnityEditor.AssetDatabase.ImportAsset(path);
    }
#endif*/
}
