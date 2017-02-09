using UnityEngine;
using System.Collections;

public class Lerp2 : MonoBehaviour {

    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

	// Use this for initialization
	void Start () {
        startPosition = target = transform.position;
	}

    public void Fuck()
    {
        Debug.Log("Called function");
    }
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime / timeToReachTarget;
        transform.position = Vector3.Lerp(startPosition, target, t);
	}
    public void  SetDestination (Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }
}
