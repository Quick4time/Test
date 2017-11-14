using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Используеться только для делегатов
public class PatternNullObject : MonoBehaviour {

    Action delegates = () => { }; // тут

    private void Start()
    {
        if (delegates != null) // вместо этой проверки в методе 
        {
            // do something
        }
    }

}
