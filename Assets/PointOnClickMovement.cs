using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointOnClickMovement : MonoBehaviour {

    public float moveSpeed = 5.0f;
    public float rotSpeed = 2.0f;
    public float deceleration = 20.0f;
    public float targetBuffer = 1.5f;
    private float _curSpeed = 0.0f;
    private Vector3 _targetPos = Vector3.one;
	
	void Update ()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetMouseButton(0)) { //¬ Задаем целевую точку по щелчку мыши.
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //¬ Испускаем луч в точку щелчка мышью.
            RaycastHit mouseHit;
            if (Physics.Raycast(ray, out mouseHit))
            {
                _targetPos = mouseHit.point; //¬ Устанавливаем цель в точке попадания луча.
                _curSpeed = moveSpeed;
            }
        }
        if (_targetPos != Vector3.one) // Перемещаем при заданой целевой точке.
        {
            Vector3 adjustedPos = new Vector3(_targetPos.x, transform.position.y, _targetPos.z);
            Quaternion targetRot = Quaternion.LookRotation(adjustedPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);// Поворочиваем по направлению к цели.

            movement = _curSpeed * Vector3.forward;
            movement = transform.TransformDirection(movement);

            if (Vector3.Distance(_targetPos, transform.position) < targetBuffer)
            {
                _curSpeed -= deceleration * Time.deltaTime;// снижаем скорость до нуля при приближении к цели.
                if (_curSpeed <= 0)
                {
                    _targetPos = Vector3.one;
                }
            }
        }
	}
}
