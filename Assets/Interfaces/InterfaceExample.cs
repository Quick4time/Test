using System;

// Пример использования интерфейса
public class InterfaceExample
{
   // Интерфейсы позволяеют добиться взаимозаменяемости частей класса, дабы не писать новвй класс раз за разом.
}

namespace InterfacePart2
{
    class Rocket
    {
        public RocketHeader Header { get; set; } // головная часть
        public IEngine Engine { get; set; }      // двигатель

        public int Weight
        {
            get
            {
                return Header.GetWeight() + Engine.Weight; // масса головной части + масса движка + масса космонавтов
            }
        }
    }

    class RocketHeader
    {
        public int Cosmonauts { get; private set; } // количество космонавтов
        public int MassShell { get; private set; }  // масса корпуса

        public RocketHeader()
        {
            Cosmonauts = 3;
            MassShell = 5000;
        }

        public int GetWeight() // возвращает общую массу модуля с учетом веса космонавтов
        {
            return (Cosmonauts * 80) + MassShell;
        }

        public void SendMessage (string message)
        {
            Console.WriteLine("Сообщение: ");
            Console.WriteLine(message);
            Console.WriteLine("отправлено");
        }
    }

    interface IEngine
    {
        void Start(); // метод для запуска
        void Stop();  // метод для остановки
        int Weight { get; } // масса двигателя
        int Power { get; }  // мощность двигателя
    }
    // Нужен для того что бы класс имел конкретные члены и свойства интерфейса.

    class HatersEngine : IEngine // двигатель летающий на тяге пердаков хуйтеров
    {
        public int Weight { get; set; }     // масса двигателя
        public int Power { get; set; }      // мощность двигателя
        public string GetCop { get; set; }  // получаем копирайты

        public HatersEngine()
        {
            Weight = 322;
            Power = 228;
            GetCop = "ExtremeCodeTV EngineCreator";
        }

        public void Start()
        {
            Console.WriteLine("Пуканы раскаляются, тяга на максимум");
        }

        public void Stop()
        {
            Console.WriteLine("Вброс годного контента. Пуканы остывают");
        }
    }


    class CryEngine : IEngine // Двигатель летающий на слезах фанатов сборной России по футболу
    {
        public int Weight { get; set; }
        public int Power { get; set; }

        public CryEngine()
        {
            Weight = 800;
            Power = 2000;
        }

        public void Start()
        {
            Console.WriteLine("То что этот двигатель не оправдывает ваши ожидания - ваши проблемы");
        }

        public void Stop()
        {
            Console.WriteLine("Прохождение в плей-оф");
        }

        public void BeginAdvertising()
        {
            Console.WriteLine("Кушайте Лейс - пи*дец как вкусно");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Rocket rocket = new Rocket();

            rocket.Header = new RocketHeader(); 
            rocket.Engine = new HatersEngine(); // upcustom приводим наследника к родителю

            Console.WriteLine("Хейтерская тяга: " + SpecialNasaMethod(rocket.Engine.Power, rocket.Weight));

            rocket.Engine = new CryEngine();
            Console.WriteLine("На слезах хейтеров: " + SpecialNasaMethod(rocket.Engine.Power, rocket.Weight));

            //rocket.Engine = new PoliticsTalksEngine();
            //Console.WriteLine("На пи*деже политиков: " + SpecialNasaMethod(rocket.Engine.Power, rocket.Weight));

            //rocket.Engine = new ShitEngine();
            //Console.WriteLine("На песнях российской эстрады: " + SpecialNasaMethod(rocket.Engine.Power, rocket.Weight));

            //rocket.Engine = new YriyLozaEngine();
            //Console.WriteLine("На пафосе Юрия Лозы: " + SpecialNasaMethod(rocket.Engine.Power, rocket.Weight));

            //Console.ReadKey();

        }


        public static int SpecialNasaMethod(int power, int mass) // метод для вычисления максимальной скорости
        {
            return (mass / power * 10) + 82;
        }
    }
}

