using UnityEngine;
using System.Collections;

// 146 Получатель Событий 
public class MyCustomListener : MonoBehaviour, IListener {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnEvent ( EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {

    }
}
