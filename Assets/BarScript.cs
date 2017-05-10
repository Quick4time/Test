using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour {

    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image content;

	void Start () {
		
	}
	
	void Update ()
    {
        HandleBar();	
	}

    private void HandleBar()
    {
        content.fillAmount = fillAmount;
    }
    // value - это значение непосредственно любое в рамках inMin(минЗначения) и inMax(максЗначения). А outMin(0.0f) и outMax(1.0f) это наш fillAmount. 
    private float Map (float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
