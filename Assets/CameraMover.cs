using UnityEngine;
using System.Collections;

/// <summary>
/// СТРАНИЦА 196.
/// </summary>
public class CameraMover : MonoBehaviour {

    public float TotalTime = 5.0f;
    public float TotalDistance = 30.0f;

    public AnimationCurve XCurve;
    public AnimationCurve YCurve;
    public AnimationCurve ZCurve;

    private Transform ThisTransform = null;

	// Use this for initialization
	void Start () {
        ThisTransform = GetComponent<Transform>();
	}
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            StartCoroutine(PlayAnim());
        }
	}
    public IEnumerator PlayAnim()
    {
        float TimeElapsed = 0.0f;

        while (TimeElapsed < TotalTime)
        {
            float NormalTime = TimeElapsed / TotalTime;

            Vector3 NewPos = ThisTransform.right.normalized * XCurve.Evaluate(NormalTime) * TotalDistance;
            NewPos += ThisTransform.up.normalized * YCurve.Evaluate(NormalTime) * TotalDistance;
            NewPos += ThisTransform.forward.normalized * ZCurve.Evaluate(NormalTime) * TotalDistance;

            ThisTransform.position = NewPos;

            yield return null;

            TimeElapsed += Time.deltaTime;
        }
    }
}
