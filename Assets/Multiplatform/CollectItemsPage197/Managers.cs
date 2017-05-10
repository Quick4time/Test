using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]
[RequireComponent(typeof(AudioManager))]
[RequireComponent(typeof(MissionManager))]
[RequireComponent(typeof(DataManager))]
//[RequireComponent(typeof(WeatherManager))]
//[RequireComponent(typeof(TestStartupScr))] // Тест загрузки Менеджера

public class Managers : MonoBehaviour {
    public static PlayerManager Player { get; private set; }
    public static InventoryManager Inventory { get; private set; }
    public static WeatherManager Weather { get; private set; }
    public static AudioManager Audio { get; private set; }
    public static MissionManager Misson { get; private set; }
    public static DataManager Data { get; private set; }

    //public static TestStartupScr TestStartUp { get; private set; } // Тест загрузки менеджера 

    private List<IGameManager> _startSequence;
    private List<INetworkManager> _startSequenceNet;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // Команда Unity для сохранения обьектов между сценами.

        Data = GetComponent<DataManager>();
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();
        Misson = GetComponent<MissionManager>();
        Weather = GetComponent<WeatherManager>();
        Audio = GetComponent<AudioManager>(); 
        //TestStartUp = GetComponent<TestStartupScr>(); // Тест загрузки менеджера

        _startSequenceNet = new List<INetworkManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        _startSequence.Add(Inventory);
        _startSequence.Add(Misson);
        _startSequence.Add(Audio);
        _startSequence.Add(Data);
        //_startSequence.Add(TestStartUp); // Тест загрузки менеджера

        StartCoroutine(StarupManagers());

    }
    private IEnumerator StatupManagersNet()
    {
        NetworkService network = new NetworkService(); // Создаются экземпляры NetworkService для вставки во все диспетчеры.

        foreach (INetworkManager managers in _startSequenceNet)
        {
            managers.Startup(network); // Во время загрузки диспетчеров передаем им сетевую службу.
        }

        yield return null;

        int numModules = _startSequenceNet.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;
            foreach (INetworkManager managers in _startSequenceNet)
            {
                if (managers.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
                Debug.Log("Progress Network: " + numReady + "/" + numModules);

            yield return null;
        }
        Debug.Log("All Network Managers started up");
    }

    private IEnumerator StarupManagers()
    {
        foreach (IGameManager managers in _startSequence)
        {
            managers.Startup();
        }
        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)// продолжаем цикл, пока не начнут работать диспетчеры.
        {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in _startSequence)
            {
                if(manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }

            if (numReady > lastReady)
                Debug.Log("Progress: " + numReady + "/" + numModules);
            Messenger<int, int>.Broadcast(StartupEvent.MANAGERS_PROGRESS, numReady, numModules); // События загрузки рассылается без параметров.
           
            yield return null;
        }
        Debug.Log("All managers started up");
        Messenger.Broadcast(StartupEvent.MANAGERS_STARTED); // События загрузки рассылается вместе с относящимся к нему данными.
    }

}
    /*
    "id": 2013159,
    "name": "Yakutsk",
    "country": "RU",
    "coord": {
      "lon": 129.733063,
      "lat": 62.03389
      */