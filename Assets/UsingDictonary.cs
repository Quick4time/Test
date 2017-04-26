using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UsingDictonary : MonoBehaviour {

    public float _myFloat = 3;
    //public Dictionary<string, int> WordDatabase = new Dictionary<string, int>();
    public Dictionary<string, GameObject> ObjectDictonary = new Dictionary<string, GameObject>();
    [SerializeField]
    GameObject _prefab1;
    [SerializeField]
    GameObject _prefab2;
    List<GameObject> _go1 = new List<GameObject>();
    List<GameObject> _go2 = new List<GameObject>();
    // Use this for initialization
    void Start() {
        /*
        someGO = new GameObject[1];
        someGO[0] = GameObject.FindGameObjectWithTag("Player");//Resources.Load("Player") as GameObject;
        someGO[1] = GameObject.FindGameObjectWithTag("Enemy");//Resources.Load("Enemy") as GameObject;
        */
        ObjectDictonary.Add("Player", _prefab1);
        //ObjectDictonary.Remove("Player");
        //ObjectDictonary.Clear();//Очистить словарь.
        ObjectDictonary.Add("Enemy", _prefab2);

        PrefabPoolSystem_AsSingleton.Prespawn(ObjectDictonary["Player"], 4);
        PrefabPoolSystem_AsSingleton.Prespawn(ObjectDictonary["Enemy"], 2);
        //WordDatabase.Add("orc", 20);
        /*
        string[] Words = new string[5];
        
        Words[0] = "hello";
        Words[1] = "car";
        Words[2] = "today";
        Words[3] = "vehicle";
        Words[4] = "comuters";

        foreach (string Word in Words)
        {
            WordDatabase.Add(Word, Words.Length);
            // Пример
            // WordDatabase.Add("hello", 5);
        }*/
        //Debug.Log("Health Orc is: " + WordDatabase["orc"].ToString());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SpawnObjectPlayer(ObjectDictonary["Player"], _go1);
            SpawnObjectEnemy(ObjectDictonary["Enemy"], _go2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            DespawnObject(_go1);
            DespawnObject(_go2);
        }
        _myFloat *= 3f;
        //Debug.Log("" + _myFloat);
    }
    void SpawnObjectPlayer (GameObject go, List<GameObject> list)
    {
        GameObject obj = PrefabPoolSystem_AsSingleton.Spawn(go, new Vector3(10,14), Quaternion.identity);
        list.Add(obj);
    }
    void SpawnObjectEnemy(GameObject go, List<GameObject> list)
    {
        GameObject obj = PrefabPoolSystem_AsSingleton.Spawn(go, new Vector3(10, 18), Quaternion.identity);
        list.Add(obj);
    }
    void DespawnObject(List<GameObject> list)
    {
        if (list.Count == 0)
        {
            return;
        }
        PrefabPoolSystem_AsSingleton.Despawn(list[0]);
        list.RemoveAt(0);
    }

}
