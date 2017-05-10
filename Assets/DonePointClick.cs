using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DonePointClick : MonoBehaviour {

    public Camera camera;
    public float moveSpeed = 5.0f;
    public float rotSpeed = 2.0f;
    public float deceleration = 20.0f;
    public float targetBuffer = 1.5f;
    private float _curSpeed = 1.0f;
    private Vector3 _targetPos = Vector3.one;

    public void OnEnable()
    {
        if (camera == null)
        {
            throw new InvalidOperationException("Camera not set");
        }
    }

    private void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetMouseButton(0))
        {
            _targetPos = camera.ScreenToWorldPoint(Input.mousePosition);
            _curSpeed = moveSpeed;
            _targetPos.z = 0;
        }
        if (_targetPos != Vector3.one)
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(0.0f, 0.0f, rot_z);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);

            movement = Vector3.MoveTowards(transform.position, _targetPos, _curSpeed * Time.deltaTime);
            movement = transform.TransformDirection(movement);

            if (Vector3.Distance(_targetPos, transform.position) < targetBuffer)
            {
                _curSpeed -= deceleration * Time.deltaTime;
                if (_curSpeed <= 0)
                {
                    _targetPos = Vector3.one;
                }
            }
            transform.position = Vector3.MoveTowards(transform.position, _targetPos, _curSpeed * Time.deltaTime);
        }      
    }
}

/*
 void Update()
 {
     Vector3 moveDirection = gameObject.transform.position - _origPos; 
     if (moveDirection != Vector3.zero) 
     {
         float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
         transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
     }
 }
*/// Возможное решение поворота.