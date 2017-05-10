using System.Collections;
using System;
using UnityEngine;

public class NetworkService {

    private const string xmlAp = "api.openweathermap.org/data/2.5/weather?q=London,uk"; // url адрес для отправки запроса.

    private bool IsResponseValid(WWW www) // Проверка на наличие ошибок.
    {
        if(www.error != null)
        {
            Debug.Log("Bad Connection");
            return false;
        }
        else if (string.IsNullOrEmpty(www.text))
        {
            Debug.Log("Bad Data");
            return false;
        }
        else
        {
            return true; // All good;
        }
    }

    private IEnumerator CallAPI (string url, Action<string> callback)
    {
        WWW www = new WWW(url); // HTTP - запрос, отправленный путем создания веб-объекта.
        yield return www;

        if (!IsResponseValid(www))
            yield break; // прерывание сопрограммы.

        callback(www.text);
    }

    public IEnumerator GetWeatherXML (Action<string> callback)
    {
        return CallAPI(xmlAp, callback);// какскад ключевых слов yield в вызывающих друг друга методах сопрограммы.
    }
}

/*
 ОПРЕДЕЛЕНИЕ Тип Action является делегатом (в C# есть ряд объяснений этому понятию, но я изложу самый простой). 
 Делегаты представляют собой ссылки на какой-то другой метод/функцию. Делегат позволяет сохранить функцию (или, точнее, указатель на нее) 
 в переменной и передать эту переменную в качестве параметра другой функции.

Если вы раньше не сталкивались с понятием делегата, представьте, что они позволяют передавать функции точно так же, как числа или строки, и вызывать их позже. 
Без делегатов мы могли бы вызывать функции только напрямую. Делегаты дают возможность сообщить коду о других методах, которые можно вызвать позже. 
Такое поведение требуется во многих случаях, особенно при реализации функций обратного вызова.

ОПРЕДЕЛЕНИЕ Обратным вызовом (callback) называется вызов функции, используемой для обмена данными с вызывающим объектом. 
Объект A может сообщить объекту B об одном из своих методов. Позднее объект B может вызвать этот метод для обмена данными с объектом A.
*/
