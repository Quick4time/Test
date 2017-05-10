using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour {

    public RectTransform healthTransform;
    private float cachedY;
    private float minXValue;
    private float maxXValue;
    private int currentHealth;
    public int maxHealth;
    private int CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth);
            HandleHealth(); // Каждый раз когда Хп изменяется мы вызываем функцию HandleHealth();
        }
    }
    
    public Text healthText;
    public Image visualHealth;
    public float coolDown = 10.0f;
    private bool onCD;
    
	void Start ()
    {
        cachedY = healthTransform.position.y;
        maxXValue = healthTransform.position.x;
        minXValue = healthTransform.position.x - healthTransform.rect.width;
        currentHealth = maxHealth;
        HandleHealth();
        onCD = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Z) && !onCD)
        {
            StartCoroutine(CoolDownDmg());
            CurrentHealth -= 1;
        }
        if(Input.GetKey(KeyCode.X) && !onCD)
        {
            StartCoroutine(CoolDownDmg());
            CurrentHealth += 1;
        }
    }

    IEnumerator CoolDownDmg()
    {
        onCD = true;
        yield return new WaitForSeconds(coolDown);
        onCD = false;
    }

    private void HandleHealth()
    {
        healthText.text = "Health: " + currentHealth;

        float currentXValue = MapValues(currentHealth, 0, maxHealth, minXValue, maxXValue);

        healthTransform.position = new Vector3(currentXValue, cachedY);

        if (currentHealth > maxHealth/2) // Больше 50%
        {
            visualHealth.color = new Color32((byte)MapValues(currentHealth, maxHealth / 2, maxHealth, 225, 0), 225, 0, 255);
        }
        else // Меньше 50%
        {
            visualHealth.color = new Color32(255, (byte)MapValues(currentHealth, 0, maxHealth / 2, 0, 255), 0, 255);
        }
    }
    private float MapValues(float x, float intMin, float inMax, float outMin, float outMax)
    {
        return (x - intMin) * (outMax - outMin) / (inMax - intMin) + outMin;
    }
}
