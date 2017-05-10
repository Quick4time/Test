using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlayer : MonoBehaviour {

    [SerializeField]
    bool _allowUpAndDownInput;
    [SerializeField]
    bool _allowLeftandRightInput;

    [SerializeField]
    float _speed; 

	void Update ()
    {
        if (Input.GetKey(KeyCode.W) && _allowUpAndDownInput)
        {
            Vector3 pos = transform.position;
            pos += Vector3.up * _speed * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.S) && _allowUpAndDownInput)
        {
            Vector3 pos = transform.position;
            pos += Vector3.down * _speed * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.A) && _allowLeftandRightInput)
        {
            Vector3 pos = transform.position;
            pos += Vector3.left * _speed * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.D) && _allowLeftandRightInput)
        {
            Vector3 pos = transform.position;
            pos += Vector3.right * _speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
