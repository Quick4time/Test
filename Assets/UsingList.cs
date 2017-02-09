using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Enemy
{
    public int Health = 100;
    public int Damage = 10;
    public int Armor = 5;
    public int ID = 0;
}


public class UsingList : MonoBehaviour
{

    public List<Enemy> Enemies = new List<Enemy>();

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Enemies.Add(new Enemy());
        }

        Enemies.RemoveRange(0, 1);

        foreach (Enemy E in Enemies)
        {
            Debug.Log(E.ID);
        }
    }
    /*void RemoveAllItems()
    {
        for (int i = Enemies.Count - 1; i >= 0; i++)
        {
            // Вызываем функцию элемента перед удалением
            //Enemies[i].MyFunc();
            Enemies.RemoveAt(i);
        }
    }
    void FixedUpdate ()
    {
        RemoveAllItems();
    }*/
}
