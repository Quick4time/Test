using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Orbiting : MonoBehaviour {

    [SerializeField]
    private Transform pivot = null;
    private Transform ThisTransform = null;
    private Quaternion DestRot = Quaternion.identity;
    // Distance to mainain from pivot
    [SerializeField]
    private float PivotDistance = 5.0f;
    [SerializeField]
    private float RotSpeed = 10.0f;
    private float RotX = 0.0f;
    private float RotY = 0.0f;

    private void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

    void Update ()
    {
        float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float Vert = CrossPlatformInputManager.GetAxis("Vertical");

        RotX += Vert * Time.deltaTime * RotSpeed;
        RotY += Horz * Time.deltaTime * RotSpeed;

        Quaternion YRot = Quaternion.Euler(0.0f, RotY, 0.0f);
        DestRot = YRot * Quaternion.Euler(RotX, 0.0f, 0.0f);
        ThisTransform.rotation = DestRot;

        // Adjust position
        ThisTransform.position = pivot.position + ThisTransform.rotation * Vector3.forward * -PivotDistance;
	}
}
