using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;

public struct Sstruct<T>
{
    public T i; //= default(int); 
    public T s; //= default(string);
    
    
    public Sstruct (T _i, T _s)
    {
        this.i = _i;
        this.s = _s;
    }
}

public class ConstructorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Sstruct<String> ss = new Sstruct<String>("1", "lol");
        Int32 i = Int32.Parse(ss.i);
        ss.s = default(String);
        //print(String.Format("int: {0}, string: {1}", ss.i.ToString(), ss.s.ToString()));
        print(string.Format("{0}", i));
        print(Add(1, 2, 3, 4, 5).ToString());

        StringBuilder sb = new StringBuilder(5); // stringBuilder своего рода конструктор для "динамических" типов стринг т.к они неизменяемые
        sb.AppendFormat("{0}", "some!");
        string s = sb.ToString().ToUpper(); // так и не добавили поддержку статических ToUpper и других методов.
        print(s);
	}

    static int Add(params Int32[] values) // неопределенное количество аргументов.
    {
        Int32 sum = 0;
        if (values != null)
        {
            for (Int32 x = 0; x < values.Length; x++)
                sum += values[x];
        }
        return sum;
    }

}
