using UnityEngine;
using System.Collections;

public class Parenter : MonoBehaviour {

    private GameObject Parent;
    private GameObject Child;

	void Start () {
        Parent = GameObject.Find("Parent");
        Child = GameObject.Find("Child");
        Child.transform.parent = Parent.transform; // Важно запомнить что transform.parent!!!! а не transform.position;
	}
}


