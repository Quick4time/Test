using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefOut : MonoBehaviour
{
    // ref

    public void Start()
    {
        var so = new  { name = "jeff", Year = 1223 }; // анонимные типы // кортежный тип

        int param = 10; // то есть инициализация происходит сразу
        testMethod(ref param); // выйдет значение = 11
        print(string.Format("Значение переменной param в методе Main = {0}", param));
    }

    static void testMethod(ref int param)
    {
        param++;
        print(string.Format("Значение переменной param в методе testMethod = {0}", param));
    }
}

public class Out : MonoBehaviour
{
    // out
    public void Start()
    {
        int param; // то есть инициализация нужна не сразу
        testMethod(out param); // выйдет значение = 11
        print(string.Format("Значение переменной param в методе Main = {0}", param));
    }

    static void testMethod(out int param)
    {
        param = 10; // иницализация происходит только тут
        param++;
        print(string.Format("Значение переменной param в методе testMethod = {0}", param));
    }
}




