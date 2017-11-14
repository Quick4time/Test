using UnityEngine;
using System.Collections;
using System.Text;

struct someStruct
{
    readonly int integer;

    someStruct(int _int)
    {
        integer = _int;
    }
}


public class MoverBad : MonoBehaviour {

    private string[,] lolstring = new string [2, 3] { { "one","two","three"}, {"four","five","six"} }; // можно без инициализации new int [,]
    // присваивание конкретному элементу массива array[2,1] = 25.
    int myInt = 5; // при статичной переменой ref все равно будет равно 10, что бы значение не менялось readonly

    private void Start()
    {
        //Debug.Log(string.Format("{0}\n{1}\n{2}\n{3}\n{4}\n{5}", lolstring[0, 0], lolstring[0, 1], lolstring[0, 2], lolstring[1, 0], lolstring[1, 1], lolstring[1, 2]));

        StringBuilder sb = new StringBuilder(50);

        // Упаковка переменных все переменные являються Object'ами
        int i = 128;
        object obj = i;

        // испосльзование упакованого значения 
        int b = (int)obj;
        

        foreach (string s in lolstring)
        {
            Debug.Log(string.Format("{0}", s));
        }

        sb.Append("Value = ");
        sb.AppendFormat(myInt.ToString());

        SomeMethod(ref myInt);
        Debug.Log(sb); // делаем не так string.Format("Value = {0}", myInt) а как показано в строке

        /*
        for (int i = 0; i < lolstring.Length; i++)
        {
            Debug.Log(" " + lolstring[i,i]);
        }
        */
    }

    void SomeMethod(ref int val)
    {
        val = 10;
    }

    // BadMove
    /*
    float AmountMove = 0.f;
	
	// Update is called once per frame
	void Update () {
        transform.localPosition += new Vector3(AmountMove, 0, 0);
	}*/

    // GoodMove
    //float speed = 1f;

    //void Update ()
    //{
    //transform.localPosition += transform.right * speed * Time.deltaTime;
    //}


}
