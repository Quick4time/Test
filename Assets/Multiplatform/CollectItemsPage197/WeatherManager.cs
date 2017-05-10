using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Глава 9 Мультиплатформа стр.210
public class WeatherManager : MonoBehaviour, INetworkManager {

    public ManagerStatus status { get; private set; } // Эта переменная может изменяться только отсюда

    private NetworkService _network;

    public void Startup(NetworkService service)
    {
        Debug.Log("Weather manager starting...");
        _network = service;// Сохранение вставленного объекта NetworkService;
        status = ManagerStatus.Started;
    }
}
