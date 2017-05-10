using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MissionManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; }

    public int curLevel { get; private set; }
    public int maxLevel { get; private set; }

    public void Startup()
    {
        Debug.Log("Mission manager starting...");

        //curLevel = 0;// устанавливает текущий уровень.
        //maxLevel = 2;// устанавливаем сколько максимум уровней.

        UpdateData(0, 2);

        status = ManagerStatus.Started;
    }

    public void GoToNext()
    {

        if (curLevel < maxLevel)// Рассылаем аргументы вместе с обектом WWW, используя обьект WWWForm.
        {
            curLevel++;
            string name = "Level" + curLevel;// Нужно называть свои уровни так Level1 т.е string Level и номер уровня.
            Debug.Log("Loading " + name);
            SceneManager.LoadScene(name); // Проверяем, дстигнут ли последний уровень.// Application.LoadLevel устаревшая используем using UnityEngine.SceneManagement; 
        }
        else
        {
            Debug.Log("Last level");
            Messenger.Broadcast(GameEvent.GAME_COMPLETE);
        }
    }

    public void UpdateData(int curLevel, int maxLevel)
    {
        this.curLevel = curLevel;
        this.maxLevel = maxLevel;
    }

    public void ReachObjective()
    {
        // здесь может быть код обработки нескольких целей.
        Messenger.Broadcast(GameEvent.LEVEL_COMPLETE);
    }
    public void RestartCurrent()
    {
        string name = "Level" + curLevel;
        Debug.Log("Loading " + name);
        SceneManager.LoadScene(name);
    }
}
