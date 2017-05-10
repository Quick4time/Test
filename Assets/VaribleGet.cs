using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaribleGet : MonoBehaviour {
    public float VarG { get; private set; } // читаем ошибку в VariableSet.

    private void Start()
    {
        VarG = 10.0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            VarG += 10.0f;
        }
    }
}
