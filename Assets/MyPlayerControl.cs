using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerControl : MonoBehaviour
{
    public int health { get; private set; }
    public int maxHealth { get; private set; }

    private void Awake()
    {
        UpdateData(50, 100);
    }

    public void UpdateData(int health, int maxHealth)
    {
        this.health = health;
        this.maxHealth = maxHealth;
    }

    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }
        if (health == 0)
        {
            Debug.Log("You are dead!");
        }
        Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
    }
    private void Update()
    {
        Debug.Log("Health: " + health + "/" + maxHealth);
    }

    public IEnumerator DoPeriodicalDamage(float damageDuration, int damageCount, int damageAmount) // код переодичного урона.
    {
        int currentCount = 0;
        while (currentCount < damageCount)
        {
            ChangeHealth(damageAmount);
            Messenger.Broadcast(GameEvent.HEALTH_UPDATED);
            yield return new WaitForSeconds(damageDuration);
            currentCount++;
        }
    }
}
