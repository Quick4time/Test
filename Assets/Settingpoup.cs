using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Settingpoup : MonoBehaviour {

    [SerializeField]
    private Slider speedSlider;
    [SerializeField]
    private TMPro.TextMeshProUGUI textPro;

    private string text;

    [HideInInspector]
    public float Speed
    {
        get { return _speed; }
        set { _speed = Mathf.Clamp(value, 0, 2);
            PlayerPrefs.SetFloat("speed", _speed);// сохранение параметров. (какое значение сохранять).
        }
    }
    private float _speed;

    private void Start()
    {
        speedSlider.value = PlayerPrefs.GetFloat("speed", 1);// сохранение параметров. (если значение отсутствует устанавливаем это знач).
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }
    /*
    public void OnSumbitName(string name)
    {
        Debug.Log(name);
    }
   
    public void OnSpeedValue(float speed)
    {
        PlayerPrefs.SetFloat("speed", speed);
        print("Speed: " + speed);
    }
    */
    private void FixedUpdate()
    {

        Debug.Log("Speed is: " + _speed );
    }
}
