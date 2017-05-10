using UnityEngine;
using System.Collections;

public class StrafingCamera : MonoBehaviour
{

    [SerializeField]
    bool _allowUpAndDown;
    [SerializeField]
    bool _allowLeftAndRight;

    [SerializeField]
    float _speed;

    void Update()
    {

        if (Input.GetKey(KeyCode.W) && _allowUpAndDown)
        {
            Vector3 pos = transform.position;
            pos += Vector3.up * _speed * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.S) && _allowUpAndDown)
        {
            Vector3 pos = transform.position;
            pos += Vector3.down * _speed * Time.deltaTime;
            transform.position = pos;
        }

        if (Input.GetKey(KeyCode.A) && _allowLeftAndRight)
        {
            Vector3 pos = transform.position;
            pos += Vector3.left * _speed * Time.deltaTime;
            transform.position = pos;
        }
        if (Input.GetKey(KeyCode.D) && _allowLeftAndRight)
        {
            Vector3 pos = transform.position;
            pos += Vector3.right * _speed * Time.deltaTime;
            transform.position = pos;
        }
    }
}
