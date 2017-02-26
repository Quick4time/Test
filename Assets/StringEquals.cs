using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StringEquals : MonoBehaviour {
    /// <summary>
    /// СРАВНЕНИЕ СТРОК.
    /// </summary>
    string stg1 = "UNITY";
    string stg2 = "unity";

    // Попробовать при необходимости найти ошибку.
    string stglarge = "hello, today is a good day to do things my way";
    string stgsearch = "good";

    public bool IsSame (string stg1, string stg2)
    {
        return string.Equals(stg1, stg2, System.StringComparison.CurrentCultureIgnoreCase);
    }

    void Start ()
    {
        Debug.Log(SearchString(stglarge, stgsearch).ToString());

            if (IsSame(stg1, stg2))
        {
            Debug.Log("IS SAME!!!");
        }
        else
        {
            Debug.Log("NOT THE SAME!!!");
        }
    }

    public void BuildString (int Num1, int Num2, float Num3)
    {
        Num1 = 2;
        Num2 = 3;
        Num3 = 4;

        string Output = string.Format("Number 1 is: {0}, Number 2 is: {1}, Number 3 is: {2}", Num1, Num2, Num3);
        Debug.Log(Output.ToString());
    }
    void LoadLevel ()
    {
        SceneManager.LoadScene("Test2");
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TestUpdate();
            //LoadLevel();
        }
    }
    void TestUpdate()
    {
        Debug.Log("123!!");
    }

    public int SearchString (string LargeStr, string SearchStr)
    {
        return LargeStr.IndexOf(SearchStr, System.StringComparison.CurrentCultureIgnoreCase);
    }
}
