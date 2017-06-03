using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Теория интерфейса
public class Iinterfaces : MonoBehaviour
{
    // Свойства int Age {get; set;}(автосвойства) Нужны для добавления проверки входных данных, либо ограничить возможности для чтения и записи данных.
    // Конвенции програмирования (свод правил программирования)
    // public int MaxSpeed(С большой буквы PascalCase); private int maxSpeed;(локальные поля классов или аргументы с маленькой буквы camelCase) public class Car; public void StatEngine(){ } Hungarian Notation private int _maxSpeed; Snake_case imena_s_podcherkivaniem(ne_uzatb:))
    // Рефакторинг - Процесс редактирования кода нацеленный нп улучшение читаемости кода, не изменяя его функциональности
    // Ctr+K,D Выравниваем скобки
    // Интерфейс - это именованный набор абстрактных членов(дебильное определение)
    // Интерфейс - это аспект языка, который служит для того, что бы формировать интерфейс взаимодействия класса(Интерфейс взаимодействия - это совокупность всех публичных членов класса).
    // Интерфейс это не наследуют, а реализуют
    // При реализации интерфейса, класс должен иметь все публичные члены интерфейса
    // Можно добавить свои свойства и методы к классу
    // Приведение к интерфейсу (upcast) Iinterface interface = new SomeMethod(); interface.Host = "Host"; и т.д Используються все методы и свойства и в классе и интерфейсе.
    // Класс может реализововать несколько интерфейсов.
}

interface Iinterface
{
    void DoSome();
}
interface Iinterface1
{
    void DoSome();
}

class Concrete : Iinterface
{
    public void DoSome()
    {
        Method(); // Но можем вызвать через любую функцию определенную в интерфейсе (например через DoSome()) Пример Инкапсуляции
    }

    public void Method() // Метод Method() неопределен в интерфейсе, при приведении к интерфейсу вызвать не сможем.
    {
        // Call method
    }
}

class Program
{
    static void Main()
    {
        Iinterface myInterface = new Concrete(); // вот это upcase
        myInterface.DoSome();
    }
}

// Что происходит, если два интерфейса обязывают реализовать одну и ту же функцию'
// 1-ый способ это когда функция будет с одной и той же реализацией

class Concrete1 : Iinterface, Iinterface1
{
    public void DoSome() // 
    {
        // Одна и та же реализация
    }
}
// 2-ой путь мы реалзовываем функцию для каждого интерфейса отдельно
class Concrete2 : Iinterface, Iinterface1
{
    void Iinterface1.DoSome()
    {
        // реализуем один интерфейс по своему.
    }

    void Iinterface.DoSome()
    {
        // реализуем другой интерфейс отличный от первого.
    }
}

// Пример использования интерфейса 
interface IWriter
{
    void Write(string text);
}
// Этот интерфейс реализуют сразу несколько классов

// Прямо в ходе программы мы можем пихать это свойства любой класс который реализует данный интерфейс, тем самым мы меняем логику экземпляра который содержиться в данном свойстве
// В этом примере мы добиваемся взаимозаменяемости классов

class ExampleInterface
{
    TextWorker textWorker = new TextWorker(); // upcase
    
    void Start()
    {
        textWorker.Writer = new StandartWriter();
        textWorker.WriteText("text"); // результат : text some
        textWorker.Writer = new BracesWriter();
        textWorker.WriteText("text"); // результат : {text some}
        textWorker.Writer = new SquareWriter();
        textWorker.WriteText("text"); // результат : [text some]
    }
}

class TextWorker
{
    public IWriter Writer { get; set; }

    public void WriteText (string text)
    {
        text += "some";
        Writer.Write(text);
    }
}

class StandartWriter : IWriter
{
    public void Write (string text)
    {
        Debug.Log(text);
    }
}

class BracesWriter : IWriter
{
    public void Write(string text)
    {
        Debug.Log("{" + text + "}");
    }
}

class SquareWriter : IWriter
{
    public void Write(string text)
    {
        Debug.Log("[" + text + "]");
    }
}
