using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAndLooking : MonoBehaviour {

    [SerializeField]
    [Range(0.0f, 180.0f)]
    private float RotSpeed = 90f;

    [SerializeField]
    [Range(0.0f, 15.0f)]
    private float Damp = 5.0f;

    public Transform target = null;

	void FixedUpdate ()
    {
        Quaternion DestRot = Quaternion.LookRotation(target.position - transform.position, Vector3.up);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, DestRot, RotSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, DestRot, Damp * Time.deltaTime);
	}
}
