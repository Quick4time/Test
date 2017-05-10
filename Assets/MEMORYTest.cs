using UnityEngine;
using System.Collections;
using System.Text;

public class ReturnTest : MonoBehaviour, IUpdateableObject {

    AudioClip _loadResourse;

    bool _return;

    void Start()
    {
        GameLogic.Instance.RegisterUpdateableObject(this);
        _return = true;
    }
    void OnDestroy()
    {
        if (GameLogic.IsAlive)
        {
            GameLogic.Instance.DeregisterUpdateableObject(this);
        }
    }

    public virtual void OnUpdate(float dt)
    {
        //ReturnMethod();
    }

    void ReturnMethod()
    {
        if (_return)
        {
            Debug.Log("returnIsWork");
            _return = false;
            // Page Optimiz 230-235.
            System.GC.Collect();// Принудительный вызов сборщика мусора. Надо включать при остановке игры. Ролика, паузы и т.д
            UnityEngine.Profiling.Profiler.GetMonoUsedSize();// Используем для проверки выделения памяти и целесообразности использования сборщика мусора.
            UnityEngine.Profiling.Profiler.GetMonoHeapSize();
            Resources.UnloadAsset(_loadResourse);// Выгрузка конкретного ресурса(Text, AudioClip и т.д) из папки Resources.
        }
        _return = true;
        return;
    }
    /*
             // Пример изменения значения по ссылке ref, при удалении myInt будет равняться 5 а не 10.
             // Страница 240, Оптимизация.
            void Start()
            {
                int myInt = 5;
                DoSomethings(ref myInt);
                Debug.Log(string.Format("Value = {0}", myInt));

            }
            void DoSomethings(ref int val)
            {
                val = 10;
            }


        // Перечитать 239-244- ПОНЯТЬ!!!!
        void Start()
        {
            string testString = "Hello";
            DoSomethings(ref testString);
            Debug.Log(testString);

        }
        void DoSomethings(ref string localstring)
        {
            localstring = "World!";
        }*/
    // Обьединение строк 246, Оптимизация.
    // Затратное обьединение строк.
    void WrongStringCombine ()
        {
        string outText = "this" + "text" + "not" + "combine" + "this";// Понятно что строка идет с определенными переменными для динамического изменения.
        // Не забываем подключить using System.Text;
        StringBuilder sb = new StringBuilder(100); // Указываем необходимый буфер (то есть количество выделенного места для строк).
        sb.Append("this"); // добавляем в StringBuilder значения по одному.
        sb.Append("text");
        // и т.д
        string result = sb.ToString();// выводим результат, который получился из StringBuilder'a.
    }
    // Пример других методов выведения и обьединения текстов.
    
    /*
    // prints hello
    string s = "hello";
    Debug.Log(s);
 

        // prints hello world
        s = string.Format("{0} {1}", s, "world");
    Debug.Log(s);

        // prints helloworld
        s = string.Concat("hello", "world");
    Debug.Log(s);

        // prints HELLOWORLD
        s = s.ToUpper();
        Debug.Log(s);

        // prints helloworld
        s = s.ToLower();
        Debug.Log(s);

        // prints 'e'
        Debug.Log(s[1]);

        // prints 42
        int i = 42;
    s = i.ToString();
        Debug.Log(s);

        // prints -43
        s = "-43";
        i = int.Parse(s);
    Debug.Log(i);

        // prints 3.141593 (an approximation)
        float f = 3.14159265359F;
    s = f.ToString();
        Debug.Log(s);

        // prints -7.141593 (an approximation)
        s = "-7.14159265358979";
        f = float.Parse(s);
    Debug.Log(f);
    */
    // Страница 250. Не создавать такие массивы, для ускорения сборки мусора.
    public struct MyStruct
    {
        int myInt;
        float myFloat;
        bool myBool;
        string myString;
    }
    MyStruct[] arraysOfStruct = new MyStruct[1000]; // Неправильный пример так кк сборщик мусора будет переберать все типы переменных.

    int[] myInts = new int[1000]; // Правильные примеры.
    float[] myFloats = new float[1000];
    bool[] myBools = new bool[1000];
    string[] myString = new string[1000]; 

    // Страница 252. Замена foreach на for.
    // Пример
    void ExampleForeachOnFor()
    {
        // Меняем это 
        foreach (Transform Child in transform)
        {
            // Делаем что-то с Child.
        }
        // На вот это
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform Child = transform.GetChild(i);
            // Делаем что-то с Child.
        }
    }
    // В коррутинах избегать yield.
}
