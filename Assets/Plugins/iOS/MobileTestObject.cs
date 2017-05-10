using System.Collections;
using UnityEngine;

public class MobileTestObject : MonoBehaviour {
    private string _message;

    private void Awake()
    {
        TestPlugin.Initialize(); // Инициализация модуля в начале кода.
    }
    private void Start() // Используем это для инициализации.
    {
        _message = "START: " + TestPlugin.TestString("ThIs Is A tEsT");
    }
    private void Update()
    {
        if (Input.touchCount == 0) // Проверяем, коснулся ли поьзователь экрана
        {
            return;
        }
        Touch touch = Input.GetTouch(0); // Ответ на ввод данных методом касания.
        if (touch.phase == TouchPhase.Began)
        {
            _message = "TOUCH: " + TestPlugin.TestNumber();
        }
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), _message); //¬ Отображение сообщения в углу экрана.
    }
}
