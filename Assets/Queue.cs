using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queue : MonoBehaviour
{
    // когда есть несколько объектов, которые должны выполняться последовательно друг за другом
    //-Dequeue: извлекает и возвращает первый элемент очереди
    //-Enqueue: добавляет элемент в конец очереди
    //-Peek: просто возвращает первый элемент из начала очереди без его удаления

    Queue<int> numbers = new Queue<int>();
    Queue<Person> persons = new Queue<Person>();

    void Start()
    {
        // добавление элементов в очередь.
        numbers.Enqueue(3); // очередь 3
        numbers.Enqueue(5); // очередь 3, 5
        numbers.Enqueue(8); // очередь 3, 5, 8    

        // получаем первый элемент очереди
        int queueElement = numbers.Dequeue(); //теперь очередь 5, 8
        print(queueElement);

        persons.Enqueue(new Person() { Name = "Tom" });
        persons.Enqueue(new Person() { Name = "Bill" });
        persons.Enqueue(new Person() { Name = "Jhon" });

        // получаем первый элемент без его извлечения
        Person pp = persons.Peek();
        print(pp.Name);

        print(string.Format("Сейчас в очереди {0} человек", persons.Count));

        // теперь в очереди Tom, Bill, Jhon
        foreach(Person p in persons)
        {
            print(p.Name);
        }

        // Извлекаем первый элемент в очереди - Tom
        Person person = persons.Dequeue(); // теперь в очереди Bill, John
        print(person.Name);

    }
}

class Person
{
    public string Name { get; set; }
}

