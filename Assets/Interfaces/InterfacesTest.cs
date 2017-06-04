using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Solider
{
    public Human Man { get; set; }
    public SSoldier Stats { get; set; } // меняем на ISolder если хотим использовать интерфейс

    public int Weight
    {
        get { return Man.Weight + Stats.MassEquip; } // !!! Запомнить что get то есть получить можно любое int значение
    }
}

class Human
{
    public int Weight { get; private set; }
    public int Height { get; private set; }

    public Human()
    {
        Weight = Random.Range(70, 85);
        Height = Random.Range(165, 190);
    }
}

interface ISolider
{
    void ReadyForDuty(); 
    string Weapon { get; set; }
    string Loadout { get; set; }
    int MassEquip { get; set; }
    string Rank { get; set; }
}


public abstract class SSoldier //interface ISolider
{
    public abstract void ReadyForDuty(); // убрать абстракт и модификатор доступа и в классе тоже
    public string Weapon { get; set; }
    public string Loadout { get; set; }
    public int MassEquip { get; set; }
    public string Rank { get; set; }
}

public static class ArrayExtension
{
    public static T RandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}

public class RussianSoldier : SSoldier
{
    public string[] weapon = new string[] { "АК74", "АК74М", "АСВал", "СВ-98", "Печенег"};
    public string Weapon { get; set; }

    public string[] loadout = new string[] { "Смерч-А", "Собр-2", "Танк", "6Ш117", "6Ш112"};// Пример инкапсуляции при наследовании этого класса эта переменная будет не видна.
    public string Loadout { get; set; } // попробовать так get { return loadout.RandomItem(); } // возможно работает в abstract variable

    public int MassEquip { get; set; }

    public string[] rank = new string[] {"Рядовой", "Сержант", "Лейтенант", "Майор", "Генерал"};
    public string Rank { get; set; }

    
    public RussianSoldier()
    {
        Rank = rank.RandomItem();
        Loadout = loadout.RandomItem();
        Weapon = weapon.RandomItem();
    }

    public override void ReadyForDuty() // убрать ovveride
    {
        Debug.Log("RuArmy");
    }
}

class USASoldier : ISolider
{
    public string Weapon { get; set; } // для Inumerator'a убираем new
    public string[] weapon = new string[] { "M4A3", "HKM27", "FN SCAR", "M40", "M249" };
    //Dictionary<string, int> weapon = new Dictionary<string, int>();

    public string Loadout { get; set; }
    public string[] loadout = new string[] { "CIRAS", "RRV", "FSBE", "JPC", "VT017" };
    //Dictionary<string, int> loadout = new Dictionary<string, int>();

    public string Rank { get; set; }
    public string[] rank = new string[] { "Private", "Sergeant", "First Lieutenant", "Capitan", "General" };
    //Dictionary<string, int> rank = new Dictionary<string, int>();

    public int MassEquip { get; set; }

    public USASoldier()
    {
        Rank = rank.RandomItem();
        Loadout = loadout.RandomItem();
        Weapon = weapon.RandomItem();
        //MassEquip = weapon.Values.Count;
    }

    public void ReadyForDuty()
    {
        Debug.Log("USArmy");
    }
}

public class InterfacesTest : MonoBehaviour
{
	void Start ()
    {
        Solider rusoldier = new Solider();
        rusoldier.Man = new Human();
        rusoldier.Stats = new RussianSoldier(); // вот это upcastom полиморфизм
        Debug.Log("Рост: " + rusoldier.Man.Height + "\nВес: " + rusoldier.Man.Weight + "\nОружие: " + rusoldier.Stats.Weapon + "\nЗвание: " + rusoldier.Stats.Rank + "\nРазгрузка: " + rusoldier.Stats.Loadout);
        rusoldier.Stats.ReadyForDuty(); // сетод абстрактным классом передает

        /* // Использование интерфейса
        Solider ussoldier = new Solider();
        ussoldier.Man = new Human();
        ussoldier.Stats = new USASoldier();
        Debug.Log("\nРост: " + ussoldier.Man.Height + "\nВес: " + ussoldier.Man.Weight  + "\nОружие: " + ussoldier.Stats.Weapon + "\nЗвание: " + ussoldier.Stats.Rank + "\nРазгрузка: " + ussoldier.Stats.Loadout);
        ussoldier.Stats.ReadyForDuty();
        */
    }
}

/*
public class SomeTest : MonoBehaviour
{
    public string Weapon { get; set; }
    public string[] weapon;

    private void Start()
    {
        weapon = new string[4];
        weapon[0] = "AK74";
        weapon[1] = "M4A3";
        weapon[2] = "ASVAL";
        weapon[3] = "M40";
        
        Weapon = weapon.RandomItem();
        print(Weapon);
    }
}

public static class ArrayExtension
{
    public static T RandomItem<T>(this T[] array)
    {
        return array[Random.Range(0, array.Length)];
    }
}
*/
