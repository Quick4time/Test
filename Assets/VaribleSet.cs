using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(VaribleGet))]
public class VaribleSet : MonoBehaviour {

    VaribleGet VarG;

    private void Awake()
    {
        VarG = GetComponent<VaribleGet>();
    }

    private void Update()
    {
        //VarG.VarG -= 10.0f; 
    }
}
