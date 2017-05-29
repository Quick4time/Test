using UnityEngine;
using System.Collections;

// 141 Исскуство создания сценариев в Unity (Событийное программирование).
public class EventSysTest : MonoBehaviour, IListener {

    public int Health
    {
        get { return _health; }
        set
        {
            _health =  Mathf.Clamp(value, 0, 100);
            EventManager.Instance.PostNotification(EVENT_TYPE.HEALTH_CHANGE, this, _health);
            /*
            if (_health <= 0) 
            {
                OnDead();             
                return;
            }
            */
        }
    }
    public int Ammo
    {
        get { return _ammo; }
        set
        {
            _ammo =  Mathf.Clamp(value, 0, 50);
            EventManager.Instance.PostNotification(EVENT_TYPE.AMMO_CHANGE, this, _ammo);
            /*if (_ammo <= 0)
            { 
                return;
            }
            if (_ammo <= 10 )
            {   
                return;
            }*/
        }
    }
    public int Mana
    {
        get { return _mana; }
        set
        {
            _mana = Mathf.Clamp(value, 0, 160);
            EventManager.Instance.PostNotification(EVENT_TYPE.MANA_CHANGE, this, _mana);
        }
    }


    private int _health = 100;
    private int _ammo = 50;
    private int _mana = 150;
	// Use this for initialization

    public void OnEvent (EVENT_TYPE Event_type, Component Sender, object Param = null)
    {
        switch(Event_type)
        {
          case EVENT_TYPE.HEALTH_CHANGE:
                OnHealthChange(Sender, (int)Param);
                break;
            case EVENT_TYPE.AMMO_CHANGE:
                OnAmmoChange(Sender, (int)Param);
                break;
            case EVENT_TYPE.MANA_CHANGE:
                OnManaChange(Sender, (int)Param);
                break;
            case EVENT_TYPE.DEAD:
                OnDead();
                break;
        }
    }
    void OnDead()
    {
        Debug.Log("DeadMBY");
    }
    void OnManaChange(Component Enemy, int NewMana)
    {
        if (this.GetInstanceID() != Enemy.GetInstanceID()) return;
        Debug.Log("Object: " + gameObject.name + " Mana is: " + NewMana.ToString());
    }

    void OnHealthChange (Component Enemy, int NewHealth)
    {
        if (this.GetInstanceID() != Enemy.GetInstanceID()) return;

        Debug.Log("Object: " + gameObject.name + "Health is: " + NewHealth.ToString());
    }
    void OnAmmoChange (Component Enemy, int NewAmmo)
    {
        if (this.GetInstanceID() != Enemy.GetInstanceID()) return;
        Debug.Log("Object: " + gameObject.name + "Ammo is: " + NewAmmo.ToString());
    }

	void Start ()
    {
        EventManager.Instance.AddListener(EVENT_TYPE.HEALTH_CHANGE, this);
        EventManager.Instance.AddListener(EVENT_TYPE.AMMO_CHANGE, this);
        EventManager.Instance.AddListener(EVENT_TYPE.MANA_CHANGE, this);
    }
}
