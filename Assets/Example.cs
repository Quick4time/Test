using UnityEngine;
using System.Collections;

// Пример с общедоступными переменными ст 284.

    [System.Serializable]
    public class Example : System.Object
{
    public int MyIntProperty
    {
        get { return _MyIntProperty; }
        set { if (value <= 10) _MyIntProperty = value; else _MyIntProperty = 0; }
    }
    public float MyFloatProperty
    {
        get { return _MyFloatProperty; }
        set { _MyFloatProperty = value; }
    }
    public Color MyColorProperty
    {
        get { return _MyColorProperty; }
        set { _MyColorProperty = value; }
    }
    
    private int _MyIntProperty;
    private float _MyFloatProperty;
    private Color _MyColorProperty;
}
