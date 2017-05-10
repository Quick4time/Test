using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryPopup : MonoBehaviour {

    [SerializeField] private Image[] itemIcons;//| Массивы для ссылки на четыре изображения.
    [SerializeField] private TMPro.TextMeshProUGUI[] itemLabels;//| Массивы для ссылки на четыре тексьовые метки.

    [SerializeField] private TMPro.TextMeshProUGUI curItemLabel;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button useButton;

    private string _curItem;

    public void Refresh()
    {
        List<string> itemList = Managers.Inventory.GetItemList();

        int len = itemIcons.Length;
        for(int i = 0; i < len; i++) 
        {
            if (i < itemList.Count) // Проверка списка инвентаря в процессе циклического просмотра всех изображений элементов UI.
            {
                itemIcons[i].gameObject.SetActive(true);
                itemLabels[i].gameObject.SetActive(true);

                string item = itemList[i];

                Sprite sprite = Resources.Load<Sprite>("Resources/Icons/" + item); // загрузка спрайта из папки Resources.
                itemIcons[i].sprite = sprite;
                itemIcons[i].SetNativeSize(); // Изменение размеров под исходный размер спрайта.

                int count = Managers.Inventory.GetItemCount(item);
                string message = "x" + count;
                if (item == Managers.Inventory.equippedItem)
                {
                    message = "Equipped\n" + message; // На метке может появиться не только количество элементов, но и слово "Equippe".
                }
                itemLabels[i].text = message;

                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerClick; // Первращаем значки в интерактивные обьекты.
                entry.callback.AddListener((BaseEventData data) => { OnItem(item); }); // Лямбда-функция, позволяющая пр-разному активировать каждый элемент.
                EventTrigger trigger = itemIcons[i].GetComponent<EventTrigger>();
                trigger.triggers.Clear();// Сбор подписчика, чтобы начать с чистого листа.
                trigger.triggers.Add(entry); // Добавление функции-подписчика к классу EventTrigger.
            }
            else
            {
                itemIcons[i].gameObject.SetActive(false);//||Скрываем изображение/текст при отсутствии элементов для отображения.
                itemLabels[i].gameObject.SetActive(false);//|
            }
        }

        if (!itemList.Contains(_curItem))
        {
            _curItem = null;
        }
        if (_curItem == null)
        {
            curItemLabel.gameObject.SetActive(false);
            equipButton.gameObject.SetActive(false);
            useButton.gameObject.SetActive(false);
        }
        else // Отображение выделенного в данный момент элемента.
        {
            curItemLabel.gameObject.SetActive(true);
            equipButton.gameObject.SetActive(true);
            if (_curItem == "Health")
            {
                useButton.gameObject.SetActive(true);
            }
            else
            {
                useButton.gameObject.SetActive(false);
            }
            curItemLabel.text = _curItem + ":";
        }
    }
    public void OnItem(string item) // Функция, вызываемая подписчиком события щелчка мыши.
    {
        _curItem = item;
        Refresh();
    }

    public void OnEquip()
    {
        Managers.Inventory.EquipItem(_curItem);
        Refresh();
    }

    public void OnUse()
    {
        Managers.Inventory.ConsumeItem(_curItem);
        if (_curItem == "Health")
        {
            Managers.Player.ChangeHealth(25);
        }
        Refresh();
    }
}
