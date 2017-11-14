using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTo : MonoBehaviour
{

    [SerializeField]
    [Range(0.0f, 180.0f)]
    private float RotSpeed = 90f;
    [SerializeField]
    private Vector3 RotVector;
    [SerializeField]
    bool reverseRotate;
    [SerializeField]
    private LayerMask mask;

    void FixedUpdate()
    {
        // поворачивает обьект с течением времени(бесконечно).
        //transform.rotation *= Quaternion.AngleAxis(RotSpeed * Time.deltaTime, RotVector);
        if (reverseRotate)
        {
            transform.rotation *= Quaternion.RotateTowards(Quaternion.identity, Quaternion.Euler(-RotVector * Time.deltaTime), 90.0f);

        }
        else
        {
            transform.rotation *= Quaternion.RotateTowards(Quaternion.identity, Quaternion.Euler(RotVector * Time.deltaTime), 90.0f);
        }
        // поворот на 90 градусов по оси y
        //transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
    }
}
