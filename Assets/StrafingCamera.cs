using UnityEngine;
using System.Collections;


public class StrafingCamera : ScriptableObject
{
    [SerializeField]
    bool _allowUpAndDown;
    [SerializeField]
    bool _allowLeftAndRight;

    [SerializeField]
    float _speed;

    void Update()
    {
        if (_allowUpAndDown)
        {
            if (Input.GetKey(KeyCode.W))
            {
                //Vector3 pos = transform.position;
                //pos += Vector3.up * _speed * Time.deltaTime;
                //transform.position = pos;
            }
            if (Input.GetKey(KeyCode.S))
            {
                //Vector3 pos = transform.position;
                //pos += Vector3.down * _speed * Time.deltaTime;
                //transform.position = pos;
            }
        }

        if(_allowLeftAndRight)
        {
            if (Input.GetKey(KeyCode.A))
            {
                //Vector3 pos = transform.position;
                //pos += Vector3.left * _speed * Time.deltaTime;
                //transform.position = pos;
            }
            if (Input.GetKey(KeyCode.D))
            {
                //Vector3 pos = transform.position;
                //pos += Vector3.right * _speed * Time.deltaTime;
                //transform.position = pos;
            }
        }
    }
}
