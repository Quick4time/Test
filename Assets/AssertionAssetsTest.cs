using UnityEngine;
using System.Collections;

public class AssertionAssetsTest : MonoBehaviour {

    int assetsTest = 1;
    [SerializeField]
    GameObject go;
    
	void Update () {
	    if (Input.GetKeyDown(KeyCode.B))
        {
            assetsTest -= 2;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            DestroyImmediate(go);
        }
        if (assetsTest < 0 || go == null)
        {
            // Изменение текста в скрипте.
            Debug.Log("<color=red>[ERROR]</color>This is a <i>very</i><size=14><b>specific</b></size> kind of log message");
        }     
	}

    // Пример от Unity
    /*
    public class ExampleClass : MonoBehaviour
    {
        public int health;
        public GameObject go;
        void Update()
        {
            //You expect the health never to be equal to zero 
            Assert.AreNotEqual(0, health);

            //The referenced GameObject should be always (in every frame) be active
            Assert.IsTrue(go.activeInHierarchy);
        }
    }
    */
}
