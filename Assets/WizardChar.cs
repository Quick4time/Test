using UnityEngine;
using System.Collections;

public class WizardChar : MonoBehaviour, IListener {


    public int Health
    {
        get { return _health; }
        set
        {_health = Mathf.Clamp(value, 0, 100);
            EventManager.Instance.PostNotification(EVENT_TYPE.HEALTH_CHANGE, this, _health);
            /*
            if (_health <= 0)
            {
                DestroyGM();
                return;
            }
            */
        }        
    }
    public int Mana
    {
        get { return _mana; }
        set { _mana = Mathf.Clamp(value, 0, 50);
            EventManager.Instance.PostNotification(EVENT_TYPE.MANA_CHANGE, this, _mana);
            /*
            if (_mana <= 0)
            {
                ManaLow();
                return;
            }
            */
        }
    }
    [SerializeField]
    private int _health;
    [SerializeField]
    private int _mana;
    
    void Awake()
    {
        
        _health = 60;
        _mana = 30;
    }

    void Start ()
    { 
        EventManager.Instance.AddListener(EVENT_TYPE.HEALTH_CHANGE, this);
        EventManager.Instance.AddListener(EVENT_TYPE.MANA_CHANGE, this);
    }
    

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
    void OnHealthChange(Component Enemy, int newHealth)
    {
        if (Health <= 0)
        {
            Debug.Log("Health is Null");
            //Destroy(gameObject);
        }
        //Debug.Log("Object: " + gameObject.name + " Damaged: " + newHealth.ToString());
    }
    void OnManaChange (Component Enemy, int newMana)
    {
            if (Mana <= 0)
        {
            Debug.Log("Mana is Null!");
            //Destroy(gameObject);
        }
            //Debug.Log("Object: " + gameObject.name + " Mana is: " + newMana.ToString());
    }

    void ManaLow()
    {
        Debug.Log("Mana Low!!!!!");
    }
    
    void DestroyGM()
    {
        DestroyObject(gameObject, 2.0f);
    }
    
    /*
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // Работает но жрет много ресурсов (попробовать найти чтонибудь менне затратное).
        {
            Health += 10;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health -= 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Mana -= 5;
        }
    }
    /*
    public bool HandleHurtMessage(BaseMessage msg)
    {
        DestroyMessege castMsg = msg as DestroyMessege;
        Health -= castMsg._damage;
        Mana -= castMsg._manaLow;
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
    */
}
