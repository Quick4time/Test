using UnityEngine;
using System.Collections;

public class ListAllComponent : MonoBehaviour {
    private Component[] AllComponent = null;
	// Use this for initialization
	void Start () {
        AllComponent = GetComponents<Component>();
        /*foreach (Component C in AllComponent)
        {
            //Debug.Log(C.ToString());
        }*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
