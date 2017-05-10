using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour, IGameManager {
    public ManagerStatus status { get; private set; } // Свойство читается откуда угодно, но задается только в этом сценарии.
    public string equippedItem { get; private set; }

    private Dictionary<string, int> _items;

    public void Startup()
    {
        Debug.Log("Inventory manager starting..."); // Сюда идут все задачи запуска с долгим временем выполнения.

        UpdateData(new Dictionary<string, int>()); //_items = new Dictionary<string, int>(); // Инициализируем пустой список элементов.

        status = ManagerStatus.Started;
    }

    public void UpdateData(Dictionary<string, int> items)
    {
        _items = items;
    }
    public Dictionary<string, int> GetData() // Необходимая функция для сохранения данных.
    {
        return _items;
    }

    private void DisplayItems() // Вывод на консоль сообщения о текущем инвинтаре.
    {
        string itemDisplay = "Items: ";
        foreach (KeyValuePair<string, int> item in _items)
        {
            itemDisplay += item.Key + "(" + item.Value + ")";
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        if (_items.ContainsKey(name))// Проверка существующих записей перед выводом новых.
        {
            _items[name] += 1;
        }
        else
        {
            _items[name] = 1;
        }
        DisplayItems();
    }
    public bool ConsumeItem(string name)
    {
        if (_items.ContainsKey(name))
        {
            _items[name]--;
            if (_items[name] == 0)
            {
                _items.Remove(name);
            }
        }
        else
        {
            Debug.Log("cannot consume " + name);
            return false;
        }
        DisplayItems();
        return true;
    }
    
    public List<string> GetItemList() // Возвращаем количество указанных элементов в инвентаре
    {
        List<string> list = new List<string>(_items.Keys);
        return list;
    }

    public int GetItemCount(string name)
    {
        if (_items.ContainsKey(name))
        {
            return _items[name];
        }
        return 0;
    }
    public bool EquipItem(string name)
    {
        if (_items.ContainsKey(name) && equippedItem != name)// Проверяем наличие в инвентаре указанного элемента и тот факт, что он еще не подготовлен к использованию.
        {
            equippedItem = name;
            Debug.Log("Equipped " + name);
            return true;
        }
        equippedItem = null;
        Debug.Log("Unequipped");
        return false;
    }
}

/* // стр 211
 Листинг 8.19. Запрос ключа в сценарии DeviceTrigger
...
public bool requireKey;
void OnTriggerEnter(Collider other) {
if (requireKey && Managers.Inventory.equippedItem != "key") {
return;
}
...
Как видите, вам потребовались всего лишь новая открытая переменная и условная инструкция для поиска подготовленного к использованию ключа. 
Логическая переменная requireKey появляется в виде флажка на панели Inspector, что позволяет требовать ключ только от определенных триггеров. 
Условие в начале метода OnTriggerEnter() проверяет наличие подготовленного ключа в диспетчере InventoryManager; соответственно, нужно добавить в 
сценарий InventoryManager код следующего листинга.
*/

