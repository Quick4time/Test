using UnityEngine;
using System.Collections;

public class StringOps : MonoBehaviour
{
    public string Mystring = null;
    
    void Lel()
    {
        if (Mystring.IsNullorWhiteSpace())
        {
            Debug.Log("lal");
        }
        else
        {
            Debug.Log("lel");
        }
    }

    void Update ()
    {
        Lel();
        if (Input.anyKeyDown)
        {
            Mystring = "string not null";
        }
    }

    public bool IsValid(string MyString)
    {
        MyString = Mystring;
        if (MyString.IsNullorWhiteSpace()) return false;
        return true;
    }
}
