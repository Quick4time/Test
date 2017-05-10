using UnityEngine;
using System.Collections;

    // Оптимизация Страница 75.
    // Непосредственно передаваемое сообщение другим классам.
    public class BaseMessage
    {
        public string name;
        public BaseMessage() { name = this.GetType().Name; }
    }

