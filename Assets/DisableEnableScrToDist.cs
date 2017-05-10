using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableEnableScrToDist : MonoBehaviour {

    public void Update()
    {
        Debug.Log("ObjectEnable!!!");
    }

    public void CustomUpdate ()
    {
        //Debug.Log("ObjectEnable!!!");// Работает независимо от enabled = true or false.
    }
}
