using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class DataManager : MonoBehaviour, IGameManager {
  
    public ManagerStatus status { get; private set; }

    private string _filename;

    public void Startup()
    {
        Debug.Log("Data manager starting...");

        _filename = Path.Combine(Application.persistentDataPath, "game.dat"); // Генерируем полный путь к файлу game.dat.

        status = ManagerStatus.Started;
    }

    public void SaveGameState()
    {
        Dictionary<string, object> gamestate = new Dictionary<string, object>(); // Словарь, который будет подвергнут сериализации.
        gamestate.Add("inventory", Managers.Inventory.GetData());  // какие данные сохраняем.
        gamestate.Add("health", Managers.Player.health);          //
        gamestate.Add("maxHealth", Managers.Player.maxHealth);   //
        gamestate.Add("curLevel", Managers.Misson.curLevel);    //
        gamestate.Add("maxLevel", Managers.Misson.maxLevel);   //

        FileStream stream = File.Create(_filename); // Создаем файл по указанному адресу.// или File.CreateText(Создает Текстовый файл).
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(stream, gamestate); // Сериализуем объект Dictonary как содержимое созданного файла.
        stream.Close();
    }
    public void LoadGameState()
    {
        if (!File.Exists(_filename))
        {
            Debug.Log("No saved game"); // переход к загрузке только при наличии фпйла.
            return;
        }
        Dictionary<string, object> gamestate; // Словарь для размещения загруженных данных.

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = File.Open(_filename, FileMode.Open);
        gamestate = formatter.Deserialize(stream) as Dictionary<string, object>;
        stream.Close();

        Managers.Inventory.UpdateData((Dictionary<string, int>)gamestate["inventory"]); // Обновляем диспетчеры, снабжая их десериализованными данными.
        Managers.Player.UpdateData((int)gamestate["health"], (int)gamestate["maxHealth"]);
        Managers.Misson.UpdateData((int)gamestate["curLevel"], (int)gamestate["maxLevel"]);
        Managers.Misson.RestartCurrent();
    }

}
