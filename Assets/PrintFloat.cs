using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintFloat : MonoBehaviour {

    // This C# function can be called by an Animation Event
    public void PrintInt(int theValue)
    {
        Debug.Log("PrintFloat is called with a value of " + theValue);
    }
}
