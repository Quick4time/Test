using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour {

    private Transform ThisTransform = null;
    #region Переменные
    public float ShakeTime = 2.0f;
    public float ShakeAmount = 3.0f;
    public float ShakeSpeed = 2.0f;
    #endregion

    #region Методы
    void Start () {

        ThisTransform = GetComponent<Transform>();	
	}

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartShake());
        }
    }
	
    public IEnumerator StartShake ()
    {
        Vector3 OriginPosition = ThisTransform.localPosition;
        float ElapsiedTime = 0.0f;

        while (ElapsiedTime < ShakeTime)
        {
            Vector3 RandomPoint = OriginPosition + Random.insideUnitSphere * ShakeAmount;
            ThisTransform.localPosition = Vector3.Lerp(ThisTransform.localPosition, RandomPoint, Time.deltaTime * ShakeAmount);
            yield return null;

            ElapsiedTime += Time.deltaTime;
        }
        ThisTransform.localPosition = OriginPosition;
    }
    #endregion
}
