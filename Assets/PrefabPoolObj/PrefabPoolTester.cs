using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabPoolTester : MonoBehaviour {
    [SerializeField]
    GameObject _prefab1;

    List<GameObject> _go1 = new List<GameObject>();

    void Start()
    {
        _go1.Clear();
        PrefabPoolSystem_AsSingleton.Prespawn(_prefab1, 4);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnObject(_prefab1, _go1);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnDespawnObject(_go1);
        }
    }
    void SpawnObject(GameObject prefab, List<GameObject> list)
    {
        GameObject obj = PrefabPoolSystem_AsSingleton.Spawn(prefab, Vector3.zero, Quaternion.identity);
        list.Add(obj);
    }
    void OnDespawnObject(List<GameObject> list)
    {
        if(list.Count == 0)
        {
            // Nothing to despawn
            return;
        }
        PrefabPoolSystem_AsSingleton.Despawn(list[0]);
        list.RemoveAt(0);
    }
	
}



// Оригинальный скрипт.
/*
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PrefabPoolTester : MonoBehaviour {

	[SerializeField] GameObject _prefab1;
	[SerializeField] GameObject _prefab2;
	[SerializeField] GameObject _prefab3;
	[SerializeField] GameObject _prefab4;

	List<GameObject> _go1 = new List<GameObject>();
	List<GameObject> _go2 = new List<GameObject>();
	List<GameObject> _go3 = new List<GameObject>();
	List<GameObject> _go4 = new List<GameObject>();

	void Start() {
		PrefabPoolSystem_AsSingleton.Prespawn(_prefab1, 3);
		PrefabPoolSystem_AsSingleton.Prespawn(_prefab4, 6);
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Alpha1)) {	SpawnObject(_prefab1, _go1); }
		if (Input.GetKeyDown(KeyCode.Alpha2)) {	SpawnObject(_prefab2, _go2); }
		if (Input.GetKeyDown(KeyCode.Alpha3)) {	SpawnObject(_prefab3, _go3); }
		if (Input.GetKeyDown(KeyCode.Alpha4)) {	SpawnObject(_prefab4, _go4); }
		if (Input.GetKeyDown(KeyCode.Q)) { DespawnRandomObject(_go1); }
		if (Input.GetKeyDown(KeyCode.W)) { DespawnRandomObject(_go2); }
		if (Input.GetKeyDown(KeyCode.E)) { DespawnRandomObject(_go3); }
		if (Input.GetKeyDown(KeyCode.R)) { DespawnRandomObject(_go4); }
		if (Input.GetKeyDown (KeyCode.Space)) {
			Application.LoadLevel ("StackHeapTest2");
		}
	}

	void SpawnObject(GameObject prefab, List<GameObject> list) {
		GameObject obj = PrefabPoolSystem_AsSingleton.Spawn (prefab, Random.insideUnitSphere * 8f, Quaternion.identity);
		list.Add (obj);
	}

	void DespawnRandomObject(List<GameObject> list) {
		if (list.Count == 0) {
			// Nothing to despawn
			return;
		}

		int i = Random.Range (0, list.Count);
		PrefabPoolSystem_AsSingleton.Despawn(list[i]);
		list.RemoveAt(i);
	}
}
*/
