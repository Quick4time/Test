﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopingMovement : MoveAndResetObj {
    [SerializeField]
    private Vector3 topPosition;
    [SerializeField]
    private Vector3 bottomPosition;
    [SerializeField]
    private float speed;

    private void Start()
    {
        StartCoroutine(Move(bottomPosition));
    }

    protected override void Update()
    {
        base.Update(); // интересный трюк куб будет двигаться с платформой
    }

    
    IEnumerator Move(Vector3 target)
    {
        while(Mathf.Abs((target - transform.localPosition).y) > 0.20f)
        {
            Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
            transform.localPosition += direction * Time.deltaTime;

            yield return null;
        }

        print("Reached the target");

        yield return new WaitForSeconds(0.5f);
        Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

        StartCoroutine(Move(newTarget));
    }

}
