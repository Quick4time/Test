using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FabriqPat
{

    // для того что бы создать неизвестный подкласс знакомого класса. т.е если нам нужно создать Транспорт но мы не знаем какой водный или наземный. 
    public interface FabricMethod // abstract or virtual void method
    {
        // Фабричный метод позволяет вместо Table t = new Table(); использовать специальный метод для создания
         void deliver( string s1, string s2);
    }

    public class Truck : FabricMethod
    {
        public void deliver(string someThing, string destination)
        {
            // Доставить по земле.
        }
    }

    public class Ship : FabricMethod
    {
        public void deliver(string someThing, string destination)
        {
            // Доставить по морю.
        }
    }

    class RoadLogistic
    {
        private Truck deliver(string someThing, string destination)
        {
            return new Truck();
        }
    }

    class SeaLogistic
    {
        private Ship deliver(string someThing, string destination)
        {
            return new Ship();
        }
    }


    public abstract class Logistic
    {
          public abstract FabricMethod createVegicle();
    }

    class SomeClientClass : MonoBehaviour
    {
        void someClientMethod (Logistic sm, string someThing, string destination)
        {
            // Создать неизвестную мебель
            FabricMethod f = sm.createVegicle();
            // не важно какой, т.к. все транспорты имеют метод deliver
            f.deliver(someThing,destination);
        }

    }


}


