using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteLookCamera : MonoBehaviour {

    private Transform target;

    private void Start()
    {
        target = Camera.main.gameObject.transform;
    }
    void Update ()
    {
        if (target != null)
            transform.rotation = target.rotation;
	}
}
