using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 У холста есть ряд доступных для редактирования параметров. Прежде всего, это параметр Render Mode, которому следует оставить значение, предлагаемое по умолчанию. Для него возможны следующие значения:
 Screen Space-Overlay — визуализация элементов UI как наложенной поверх вида с камеры двухмерной графики(предлагается по умолчанию).
 Screen Space-Camera — элементы UI также визуализируются поверх вида с камеры, но могут поворачиваться, создавая эффекты перспективы.
 World Space — холст помещается в сцену, что делает элементы UI частью трехмерной сцены.
 Последние два режима применяются для создания специальных эффектов, но имеют несколько более сложную реализацию по сравнению с режимом, предлагаемым по умолчанию.
 Еще одной важной настройкой является флажок Pixel Perfect. После его установки положение изображений в процессе визуализации слегка корректируется с целью придать им четкий и контрастный вид (в отличие от размывания). Установите этот флажок, и холст готов к размещению спрайтов.
 */

public class BasicUI : MonoBehaviour {

    private void OnGUI()
    {
        int posX = 10;
        int posY = 500;
        int widith = 100;
        int height = 30;
        int buffer = 10;

        List<string> itemList = Managers.Inventory.GetItemList();

        if (itemList.Count == 0)// Отображает сообщение, информирующие об отсутствии инвентаря.
        {
            GUI.Box(new Rect(posX, posY, widith, height), "No Items");
        }
        foreach (string item in itemList)
        {
            int count = Managers.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>("Icon/" + item); // Метод загружающий ресурсы из папки Resources.
            GUI.Box(new Rect(posX, posY, widith, height), new GUIContent("(" + count + ")", image));
            posX += widith + buffer;// При каждом прохождении цикла сдвигаемся в сторону.
        }

        string equipped = Managers.Inventory.equippedItem;
        if (equipped != null) // Отображение подготовленного элемента.
        {
            posX = Screen.width - (widith + buffer);
            Texture2D image = Resources.Load("Icons/" + equipped) as Texture2D;
            GUI.Box(new Rect(posX, posY, widith, height), new GUIContent("Equipped", image));
        }
        posX = 10;
        posY += height + buffer;

        foreach (string item in itemList)// Просмотр всех элементов в цикле для создания кнопок.
        {
            if (GUI.Button(new Rect(posX, posY, widith, height), "Equip " + item))// Запуск вложенного кода при щелчке на кнопке.
            {
                Managers.Inventory.EquipItem(item);
            }
            if (item == "Health")
            {
                if (GUI.Button(new Rect(posX, posY + height+buffer, widith, height), "Use Health"))
                {
                    Managers.Inventory.ConsumeItem("Health");
                    Managers.Player.ChangeHealth(25);
                }
            }
            posX += widith + buffer;
        }
        /* // Не работает слишком частое обновления.
        if (Input.GetKeyDown(KeyCode.I))
        {
            Managers.Player.ChangeHealth(-25);
        }
        */
    }






    /*
    bool getinputx;
    bool getinputy;
    int counterButtons = 0;

    private void Start()
    {
        getinputx = (Input.GetKeyDown(KeyCode.X));
        getinputy = (Input.GetKeyDown(KeyCode.Y));
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 40, 20), "Test"))
        {
            Debug.Log("Test Button");
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            counterButtons++;
            Messenger.Broadcast(GameEvent.ENEMY_HIT);
        }
        if(Input.GetKeyDown(KeyCode.Y))
        {
            counterButtons--;
            Messenger.Broadcast(GameEvent.ENEMY_HEAL);
        }
        Debug.Log("Counter is: " + counterButtons);
    }
    */
}
