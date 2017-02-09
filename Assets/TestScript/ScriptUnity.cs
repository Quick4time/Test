using UnityEngine;
using System.Collections;

public class ScriptUnity : MonoBehaviour {

    Refernce _ref;
    GameObject go;

    EventSysTest EvSyTe;
    GameObject GM_Obj;

	void Start () {
        // пример ссылки на скрипт другого игрового обьекта .
        GM_Obj = GameObject.Find("GM");
        go = GameObject.Find("Player");
        EvSyTe = (EventSysTest)GM_Obj.GetComponent(typeof(EventSysTest));
        _ref = (Refernce)go.GetComponent(typeof(Refernce));
    }
    void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _ref.Inst();// пример использования функции из другого скрипта игрового обьекта.
            //Debug.Log("Номер " + _ref.num01); // пример использования переменной из другого скрипта игрового обьекта.
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            EvSyTe.Ammo -= 20; // Ссылка на событийное программирование. (Ammo а не _ammo).
        }
        if (Input.GetKeyDown (KeyCode.G))
        {
            EvSyTe.Health -= 10;
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            EvSyTe.Mana -= 15;
        }
        

    }
}
