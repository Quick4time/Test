using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveAndResetObj : MonoBehaviour {

    private float objectSpeed = 4.0f;
    [SerializeField]
    private float resetPos = -4.65f;

    protected virtual void Update()
    {
        transform.Translate(Vector3.left * (objectSpeed * Time.deltaTime));

        if (transform.localPosition.x <= resetPos)
        {
            Vector3 newPos = new Vector3(6, transform.position.y, transform.position.z);
            transform.position = newPos;
        }
    }
}
