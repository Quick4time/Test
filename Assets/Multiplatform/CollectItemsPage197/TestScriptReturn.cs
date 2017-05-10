using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptReturn : MonoBehaviour {
    [SerializeField]
    private bool somebool;

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.I))
        {
            SomeBoolTest();
        }
        */
        Debug.Log(" " + SomeBoolTest().ToString());
    }

    bool SomeBoolTest()
    {
        if (somebool) // если значение somebool true то true возвращается методу SomeBoolTest();
        {
            return true;
        }
        return false; // если значение somebool false то false возвращается методу SomeBoolTest();

    }
}
