using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Оптимизация Unity - Profiler. Страница 38 && Страница 42.
public class ProfilerScript : MonoBehaviour {
    //void\s* Update\s*?\(\s*\)\s*?\n*?\{\n*?\s*?\} Жмем Ctrl+F и вводим это регулярное выражение на поиск пустых методов где Update это название Метода(стр 62).

void Awake()
    {
        Application.targetFrameRate = 60; // Достижения определенного кадра в секунду.
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Y))
        {
            int numTests = 1000;

            using (new CustomTimerOptimiztion("Controlled Test", numTests))
            {
                for (int i = 0; i < numTests; i++)
                {
                    DoSomethingSupid(); // Подставляем любой метод.
                }
            }
        }
        //DoSomethingSupid();
    }


    void DoSomethingSupid()
    {
        UnityEngine.Profiling.Profiler.BeginSample("MyProfilertest"); // Проверка спомощью профелера. //1
        List<int> listOfInts = new List<int>();
        for (int i = 0; i < 1000; i++)
        {
            listOfInts.Add(i);
        }
        UnityEngine.Profiling.Profiler.EndSample();// 2
    }

}
