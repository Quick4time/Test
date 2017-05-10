using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveComplete : MonoBehaviour
{
    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }
    private void Start ()
    {
        OnHealthUpdated();
    }
    private void OnDestroy()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Managers.Misson.ReachObjective();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Managers.Player.ChangeHealth(-25);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Managers.Player.ChangeHealth(+25);
        }
    }
    private void OnHealthUpdated() // ¬ Подписчик события вызывает функцию для обновления метки health.
    {
        Debug.Log("Health is: " + Managers.Player.health + "/" + Managers.Player.maxHealth);
    }
}
