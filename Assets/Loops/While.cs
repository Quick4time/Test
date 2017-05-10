using UnityEngine;
using System.Collections;

public class While : MonoBehaviour {

	void Start ()
    {
        int NumbersOfIncrement = 0; 
        while (NumbersOfIncrement < 6)
        {
            Debug.Log("This is Increment: " + NumbersOfIncrement.ToString()); 
            ++NumbersOfIncrement;
        }	
	}
}
