using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }

    public int health { get; private set; }//т.е задается значение только в этом коде, но читается из любого кода.
    public int maxHealth { get; private set; }

    public void Startup()
    {
        Debug.Log("Player manager starting...");

        //health = 50;// Эти значения могут быть инициализированы сохраненными данными.
        //maxHealth = 100;// Эти значения могут быть инициализированы сохраненными данными.

        UpdateData(50, 100);

        status = ManagerStatus.Started;   
    }

    public void UpdateData(int health, int maxHealth)
    {
        this.health = health;
        this.maxHealth = maxHealth;
    }

    public void ChangeHealth(int value)// Другие сценарии не могут напрямую задавать переменную health, но могут вызывать эту функцию.
    {
        health += value;
        if (health > maxHealth )
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }

        if (health == 0)
        {
            Messenger.Broadcast(GameEvent.LELVEL_FAILED);
        }
        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
        /*
         Это сообщение рассылается каждый раз, когда метод ChangeHealth() завершает свою работу, сообщая остальной программе об изменении параметра health. 
         В качестве реакции на это событие должна меняться метка health, поэтому создайте сценарий UIController и введите в него код следующего листинга. 
        */
    }
    public void Respawn()
    {
        UpdateData(50, 100);
    }
}
