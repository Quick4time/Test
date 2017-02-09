using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;

public class SearchString : MonoBehaviour {

    // Пояснение на 221 странице. Поиск строк в тексте.
    string search = "[dwmf]ay";
    string txt = "hello, today is a good day to do things my way, say, may, fay";

    void Start ()
    {
        Match m = Regex.Match(txt, search);  
        while (m.Success)
        {
            Debug.Log(m.Value);
            m = m.NextMatch();
        }          	
	}
}
