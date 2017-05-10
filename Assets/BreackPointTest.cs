using UnityEngine;
using System.Collections;

public class BreackPointTest : MonoBehaviour {

	private int _fuckit  = 360;

	void Update () {
		if (_fuckit == 360) {
			_fuckit -= 30;
		} 
		else 
		{
			_fuckit += 60;	
		}
		//Debug.Log ("Score: " + _fuckit);
	}
}
