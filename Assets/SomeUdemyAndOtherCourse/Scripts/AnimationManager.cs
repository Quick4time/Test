﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance = null;

    [SerializeField] private List<GameObject> cameras = new List<GameObject>();

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }else if (instance != this){
            Destroy(gameObject);
        }
    }

    private void StartNextCamera()
    {
        if(cameras.Count > 0)
        {
            cameras[0].SetActive(true);
        }
    }
    public void DestroyCamera(GameObject camera)
    {
        cameras.RemoveAt(0);
        Destroy(camera);
        StartNextCamera();
    }
}
