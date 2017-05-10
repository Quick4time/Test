using UnityEngine;
using System.Collections;

public class Foreach : MonoBehaviour
{
    public GameObject[] MyObject;

	void Start ()
    {
	    foreach (GameObject Obj in MyObject)
        {
            DestroyImmediate(Obj);
        }
	} 
}
