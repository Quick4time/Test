using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float MaxSpeed = 10.0f;
    [SerializeField]
    private float RotSpeed = 5.0f;

    private Transform ThisTransform = null;

    private void Awake()
    {
        ThisTransform = GetComponent<Transform>();
    }

    void Update ()
    {
        float Horz = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Horizontal");
        float Vert = UnityStandardAssets.CrossPlatformInput.CrossPlatformInputManager.GetAxis("Vertical");

        // Update rotation
        ThisTransform.rotation *= Quaternion.Euler(0.0f, RotSpeed * Horz * Time.deltaTime, 0.0f);

        // Update motion
        ThisTransform.position += ThisTransform.forward * MaxSpeed * Vert * Time.deltaTime;
    }
}
