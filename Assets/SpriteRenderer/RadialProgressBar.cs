using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RadialProgressBar : MonoBehaviour { //IListener 
                                                 // Скрипт не работает (Причина IListener точнее некоректное использование).
                                                 // Тест Messenger'а с флоат.
                                                 //public float test = 1.0f;
                                                 //public const float testMesFloat = 3.0f;


    /*
    {
        get { return _fillamount; }
        set
        {
            _fillamount = Mathf.Clamp(value, 0.0f, 100.0f);
            EventManager.Instance.PostNotification(EVENT_TYPE.FILLAMOUNT_CHANGE, this, _fillamount);
        }
    }
    [SerializeField]
    private float _fillamount = 100.0f;
    */
    private float MaxHealth;
    private float CurrentlyHealth
    {
        get { return currentlyHealth; }
        set { currentlyHealth = Mathf.Clamp(value, 0.0f, MaxHealth);
            //HandleBar(); // Добавляем метод сюда и он обновляется только при отнимании хп.
            //ColorChanging();
            // можно добавить вот этот листинг valuetext
            /*
            string[] tmp = percentText.text.Split(':'); // разделяет текст.
            percentText.text = tmp[0] + ": " + value;
            */
        }
    }
    private float currentlyHealth;
    [SerializeField]
    private Image content;
    [SerializeField]
    TextMeshProUGUI percentText;
    [SerializeField]
    TextMeshProUGUI healthText;
    private float ColorSmooth = 4.0f;
    private Color32 CurrentlyColor;
    [SerializeField]
    private float perodicDamage = 10.0f;

    Color32 DefColor;
    Color32 MedColor;
    Color32 LowColor;
    
    /*
    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null)
    {
        switch (Event_Type)
        {
            case EVENT_TYPE.FILLAMOUNT_CHANGE:
                OnColorChange(Sender, (float)Param);
                break;
        }
    }
    */

    private void Awake()
    {
        //Messenger.AddListener(GameEvent.TEST_CHANGE, OnTestChange);
        CurrentlyColor = new Color32(43, 165, 0, 255);
        percentText.color = CurrentlyColor;
        healthText.color = CurrentlyColor;
    }
    /*
    private void OnDestroy()
    {
        Messenger.AddListener(GameEvent.TEST_CHANGE, OnTestChange);
    }*/

    void Start()
    {
        MaxHealth = 250.0f;
        //EventManager.Instance.AddListener(EVENT_TYPE.FILLAMOUNT_CHANGE, this);
        //_fillamount = 40.0f;
        DefColor = CurrentlyColor;
        MedColor = new Color32 (255, 180, 0, 255);
        LowColor = new Color32 (217, 28, 0, 255);
        
    }
    /*
    private void OnTestChange()
    {
        test = 10.0f;
        Debug.Log("Change.Mes");
    }
    */
    

    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.K))
        {
            fillAmount -= 10.0f;
        }
        
        if (Input.GetKeyDown(KeyCode.K))
        {
            Messenger.Broadcast(GameEvent.TEST_CHANGE);
        }
        */
        //Debug.Log("test: " + test + "," + "TestMesFloat: " + testMesFloat);
        if (Input.GetKeyDown(KeyCode.K))
        {
            CurrentlyHealth += perodicDamage;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            MaxHealth += 20.0f;
        }
        //ColorChanging();
        HandleBar(); // добавляем сюда и он обновляется как при += хп так и при его -=;
    }

    void HandleBar()
    {
        content.fillAmount = Map(currentlyHealth, 0, MaxHealth, 0, 1);
        if (currentlyHealth >= 0.0f)
        {
            percentText.text = ((int)currentlyHealth).ToString();
        }
        if (currentlyHealth > MaxHealth/2)
        {
            content.color = new Color32((byte)Map(currentlyHealth, MaxHealth / 2, MaxHealth, 255, 0), 255, 0, 255);
        }
        else
        {
            content.color = new Color32(255, (byte)Map(currentlyHealth, 0, MaxHealth / 2, 0, 255), 0, 255);
        }
    }
    public static Color ConvertColor(int r, int g, int b, int a)
    {
        return new Color(r / 255.0f, g / 255.0f, b / 255.0f, a / 255.0f);
    }
    /*
    void OnColorChange(Component Radial, float newAmount)
    {
        if (this.GetInstanceID() != Radial.GetInstanceID()) return;
        Debug.Log("Object: " + gameObject.name + " Amount is: " + newAmount.ToString());
    }
    */
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
    void ColorChanging ()
    {
        Color32 ColorBarA = DefColor;
        Color32 ColorBarB = MedColor;
        Color32 ColorBarC = LowColor;

        if (currentlyHealth >= MaxHealth/2)
        {
            CurrentlyColor = ColorBarA;
            healthText.text = "Full HP";
        }
        if (currentlyHealth <= MaxHealth/2)
        {
            CurrentlyColor = ColorBarB;
            healthText.text = "Med HP";
        }
        if (currentlyHealth <= MaxHealth/3)
        {
            CurrentlyColor = ColorBarC;
            healthText.text = "Low HP";
        }
        if (currentlyHealth <= 0.0f)
        {
            healthText.text = "You Dead(";
        }
        
        content.color = Color32.Lerp(content.color, CurrentlyColor, Time.deltaTime * ColorSmooth);
        percentText.color = Color32.Lerp(percentText.color, CurrentlyColor, Time.deltaTime * ColorSmooth);
        healthText.color = Color32.Lerp(healthText.color, CurrentlyColor, Time.deltaTime * ColorSmooth);
    }
}
