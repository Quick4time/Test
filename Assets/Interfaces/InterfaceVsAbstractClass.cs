using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceVsAbstractClass : Bus {
    // Интерфейс позволяет определять некоторый функционал, не имеющий конкретной реализации.
    // Абстрактный класс - базовый класс, который не предпологает создания экземпляров и может содержать в себе не реализованные члены
    // но при этом он может включать в себя реализованные члены - методы и свойства, которые будут доступны наследникам.

    private void Start()
    {
        Move();
    }
}

public interface Interf
{

    void Move();
}

public class VehicleInterface : MonoBehaviour, Interf
{
    public void Move()
    {
        Debug.Log("Interface");
    }
}


// Пример abstract class
public abstract class VehicleAbstract : MonoBehaviour
{
    public abstract void Move(); // имеет один абстрактный член
    public abstract int set { get; set; }
}
public class Bus : VehicleAbstract
{
    public override int set { get; set; }

    public override void Move()
    {
        Debug.Log("AbstractClass");
        // Реализуем метод
    }
}
// Вывод : Использование абстрактных классов 1) Общая функциональность для родственных обьектов
// 2) Необходимость в базовой функциональности для дочерних обьектов
// Использование интерфейсов 1) Общий интерфейс взаимодействия для разрозненных типов
// 2) Для небольших типов

    // P.S Возможно использовать оба способа в одном классе.
