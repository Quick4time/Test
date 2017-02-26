using UnityEngine;
using System.Collections;

public class WizardChar : MonoBehaviour {

    public int Health
    {
        get { return _health; }
        set
        {_health = Mathf.Clamp(value, 0, 100);
            //EventManager.Instance.PostNotification(EVENT_TYPE.HEALTH_CHANGE, this, _health);
            /*if (_health <= 0)
            {
                DestroyGM();
                return;
            }*/
        }        
    }
    public int Mana
    {
        get { return _mana; }
        set { _mana = Mathf.Clamp(value, 0, 50);
            //EventManager.Instance.PostNotification(EVENT_TYPE.MANA_CHANGE, this, _health);
            /*if (_mana <= 0)
            {
                ManaLow();
                return;
            }*/
        }
    }
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _mana;
    

    void Start ()
    {
        MessagingSystem.Instance.AttachListener(typeof(DestroyMessege), this.HandleHurtMessage);
        //EventManager.Instance.AddListener(EVENT_TYPE.HEALTH_CHANGE, this);
        //EventManager.Instance.AddListener(EVENT_TYPE.MANA_CHANGE, this);
    }
    
/*
    public void OnEvent(EVENT_TYPE Event_type, Component Sender, object Param = null)
    {
        switch (Event_type)
        {
            case EVENT_TYPE.HEALTH_CHANGE:
                OnHealthChange(Sender, (int)Param);
                break;
            case EVENT_TYPE.MANA_CHANGE:
                OnManaChange(Sender, (int)Param);
                break;
        }
    }
    void OnHealthChange(Component Enemy, int Damage)
    {
        if (this.GetInstanceID() != Enemy.GetInstanceID()) return;
        Debug.Log("Object: " + gameObject.name + " Damaged: " + Damage.ToString());
    }
    void OnManaChange (Component Enemy, int newManaint)
    {
        if (this.GetInstanceID() != Enemy.GetInstanceID()) return;
        newManaint = 10;
        if(Input.GetKeyDown(KeyCode.Space))
            Debug.Log("Object: " + gameObject.name + " Mana is: " + newManaint.ToString());
    }
    */
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health -= 20;
            Mana -= 30;
        }
        */
        Debug.Log("Health: " + Health + "Mana: " + Mana);
    }
    /*
    void ManaLow()
    {
        Debug.Log("Hey Mana is: " + Mana);
    }
    void DestroyGM()
    {
        Destroy(gameObject);
    }
    */
    bool HandleHurtMessage(BaseMessage msg)
    {
        DestroyMessege castMsg = msg as DestroyMessege;
        _health = castMsg._damage;
        _mana = castMsg._manaLow;
        //Health -= castMsg._damage;
        //Mana -= castMsg._manaLow;
        return true;
    }
    void OnDestroy()
    {
        if (MessagingSystem.IsAlive)
        {
            MessagingSystem.Instance.DetachListener(typeof(DestroyMessege), this.HandleHurtMessage);
        }
    }
}
