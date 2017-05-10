using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStartupScr : MonoBehaviour, IGameManager {
    // Тест менеджер
    public ManagerStatus status { get; private set; }

    public void Startup()
    { 
        Debug.Log("TestStartupscr: " + status.ToString());
        status = ManagerStatus.Started;
    }

}
