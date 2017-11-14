using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLocalSpace : MonoBehaviour {

    [SerializeField]
    private float DisplaceSpeed = 2.0f;
    private Transform ThisTransform = null;
    [SerializeField]
    private Vector3 LocalForward;
    [SerializeField]
    private Vector3 TransformForward;

    private void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }
    
    void Update ()
    {
        LocalForward = Vector3.forward;
        TransformForward = ThisTransform.forward;

        Vector3 LocalSpaceDisplacement = Vector3.forward * DisplaceSpeed * Time.deltaTime;
        //Vector3 WorldSpaceDisplacement = ThisTransform.TransformDirection(LocalSpaceDisplacement);

        Vector3 WorldSpaceDisplacement = ThisTransform.rotation * LocalSpaceDisplacement;

        ThisTransform.position += WorldSpaceDisplacement;
    }
}
