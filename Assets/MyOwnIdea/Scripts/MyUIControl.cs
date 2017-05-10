using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Do CanvasAlpha.
public class MyUIControl : MonoBehaviour {
    #region Переменные FadeCanvas
    [SerializeField]
    Canvas GMCanvas;
    CanvasGroup CanvasGr;
    bool showCanvas;

    private float changeTimeSeconds = 2.0f;
    private float startAlpha = 0.0f;
    private float endAlpha = 1.0f;

    private float changeRate = 0;
    private float timeSoFar = 0;
    private bool fading = false;
    #endregion

    MyPlayerControl playerManager;
    GameObject playerManagobj;
    [SerializeField]
    Image content;
    [SerializeField]
    TMPro.TextMeshProUGUI textContent;

    private void Awake()
    {
        Messenger.AddListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }
    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.HEALTH_UPDATED, OnHealthUpdated);
    }

    private void Start()
    {
        playerManagobj = this.gameObject;
        playerManager = (MyPlayerControl)playerManagobj.GetComponent(typeof(MyPlayerControl));
        CanvasGr = GMCanvas.gameObject.AddComponent<CanvasGroup>();
        OnHealthUpdated();
        if (CanvasGr == null)
        {
            Debug.Log("Должны добавить canvas group");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && showCanvas)
        {
            showCanvas = false;
            FadeIn();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && !showCanvas)
        {
            showCanvas = true;
            FadeOut();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(playerManager.DoPeriodicalDamage(0.3f, 5, -3));
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(playerManager.DoPeriodicalDamage(0.3f, 5, 3));
        }
    }
    void OnHealthUpdated()
    {
        content.fillAmount = Map(playerManager.health, 0.0f, playerManager.maxHealth, 0.0f, 1.0f);
        string messege = "Health: " + playerManager.health + "/" + playerManager.maxHealth;
        textContent.text = messege;
    }
    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
    /* // Странный код.
    static public GameObject getChildGameObject (GameObject fromGameObject, string withName)
    {
        Transform[] ts = fromGameObject.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts)
        {
            if (t.gameObject.name == withName)
            {
                return t.gameObject;
            }
        }
        return null;
    }
    */
    #region Методы CanvasFade
    private void FadeIn()
    {
        startAlpha = 0.0f;
        endAlpha = 1.0f;
        timeSoFar = 0.0f;
        fading = true;
        StartCoroutine(FadeCoroutine());
    }
    private void FadeOut()
    {
        startAlpha = 1.0f;
        endAlpha = 0.0f;
        timeSoFar = 0.0f;
        fading = true;
        StartCoroutine(FadeCoroutine());
    }
    IEnumerator FadeCoroutine()
    {
        changeRate = (endAlpha - startAlpha) / changeTimeSeconds;
        SetAlpha(startAlpha);
        while(fading)
        {
            timeSoFar += Time.deltaTime;
            if (timeSoFar > changeTimeSeconds)
            {
                fading = false;
                SetAlpha(endAlpha);
                yield break;
            }
            else
            {
                SetAlpha(CanvasGr.alpha + (changeRate * Time.deltaTime));
            }
            yield return null;
        }
    }
    private void SetAlpha(float alpha)
    {
        CanvasGr.alpha = Mathf.Clamp(alpha,0, 1);
    }
#endregion
}

//Color FadeTo
/*
  void Update ()
 {
     if(Input.GetKeyUp(KeyCode.T))
     {
         StartCoroutine(FadeTo(0.0f, 1.0f));
     }
     if(Input.GetKeyUp(KeyCode.F))
     {
         StartCoroutine(FadeTo(1.0f, 1.0f));
     }
 }
 
 IEnumerator FadeTo(float aValue, float aTime)
 {
     float alpha = transform.renderer.material.color.a;
     for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
     {
         Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
         transform.renderer.material.color = newColor;
         yield return null;
     }
 }
*/
