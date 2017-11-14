using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class TerrainHover : MonoBehaviour {

    private Transform ThisTransform = null;

    [Range(0.0f, 15.0f)]
    [SerializeField]
    private float MaxSpeed = 10.0f;
    private float DistanceFromGround = 2.0f;
    private Vector3 DestUp = Vector3.zero;
    private float AngleSpeed = 5.0f;

    private void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

    void Update ()
    {
        float Horz = CrossPlatformInputManager.GetAxis("Horizontal");
        float Vert = CrossPlatformInputManager.GetAxis("Vertical");

        Vector3 NewPos = ThisTransform.position;
        NewPos += ThisTransform.forward * Vert * MaxSpeed * Time.deltaTime;
        NewPos += ThisTransform.right * Horz * MaxSpeed * Time.deltaTime;

        RaycastHit hit;
        if(Physics.Raycast(ThisTransform.position, Vector3.down, out hit))
        {
            NewPos.y = (hit.point + Vector3.up * DistanceFromGround).y;
            DestUp = hit.normal;
        }
        ThisTransform.position = NewPos;
        ThisTransform.up = Vector3.Slerp(ThisTransform.up, DestUp, AngleSpeed * Time.deltaTime);
    }
}
