using UnityEngine;
using System.Collections;

public class MoverBad : MonoBehaviour {

    // BadMove
    /*
    float AmountMove = 0.f;
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += new Vector3(AmountMove, 0, 0);
	}*/

    // GoodMove
    float speed = 1f;

    void Update ()
    {
        transform.localPosition += transform.right * speed * Time.deltaTime;
    }
}
