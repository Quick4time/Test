using UnityEngine;
using System.Collections;
using System.Collections.Generic;


// Стаическая пакетная обработка в отличии от динамической в том что статическая обработка происходит при инициализации а динамическая во время выполнения.
[System.Serializable]
public struct GameObjectList
{
    public string name;
    public List<GameObject> _object;
}

public class StaticBatchTester : MonoBehaviour {

    [SerializeField]
    List<GameObjectList> _objectList;

	void Update ()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
        {
            BatchObject();
        }
	}
    void BatchObject()
    {
        for(int i = 0; i < _objectList.Count; ++i)
        {
            GameObjectList list = _objectList[i];
            for (int j = 0; j < list._object.Count; j++)
            {
                StaticBatchingUtility.Combine(list._object.ToArray(), gameObject);
            }
        }
    }
}
