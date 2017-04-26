using UnityEngine;
using System.Collections;
// 146 Интерфейс Listener

    public enum EVENT_TYPE { GAME_INIT, GAME_END, AMMO_CHANGE, HEALTH_CHANGE, MANA_CHANGE, DEAD, FILLAMOUNT_CHANGE }

    public interface IListener
    {
        void OnEvent (EVENT_TYPE Event_Type, Component Sender, object Param = null);
    }


