using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour {

    private Vector3 _target;
    public Camera Camera;
    public bool _followMouse = true;
    public bool ShipAccelerates;
    public float ShipSpeed = 2.0f;
    public bool LookAt;

    public void OnEnable()
    {
        if (Camera == null)
        {
            throw new InvalidOperationException("Camera not set");
        }
    }

    public void Update()
    {
        if (_followMouse || Input.GetMouseButton(0))
        {
            _target = Camera.ScreenToWorldPoint(Input.mousePosition);
            _target.z = 0;
            LookAt = true;
        }
        if (LookAt)
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, rot_z); // rot_z - 90 значитчто спрайт будет смотреть по оси y, если же мы оставим просто rot_z то по оси х.
        }

        float delta = ShipSpeed * Time.deltaTime;
        if (ShipAccelerates)
        {
            delta *= Vector3.Distance(transform.position, _target);
        }

        transform.position = Vector3.MoveTowards(transform.position, _target, delta);
    }
}
