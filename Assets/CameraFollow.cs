using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
    // СТРАНИЦА 194.
    public Transform Target = null;
    private Transform ThisTransform = null;

    public float DistanceFromTarget = 10.0f;
    public float CamHigh = 1f;
    public float RotationDamp = 4f;
    public float PosDamp = 4f;

	void Awake ()
    {
        ThisTransform = GetComponent<Transform>();
    }

	void LateUpdate () {

        Vector3 velocity = Vector3.zero;
        ThisTransform.rotation = Quaternion.Slerp(ThisTransform.rotation, Target.rotation, RotationDamp * Time.deltaTime);
        Vector3 Dest = ThisTransform.position = Vector3.SmoothDamp(ThisTransform.position, Target.position, ref velocity, PosDamp * Time.deltaTime);
        ThisTransform.position = Dest - ThisTransform.forward * DistanceFromTarget;
        ThisTransform.position = new Vector3(ThisTransform.position.x, CamHigh, ThisTransform.position.z);
        ThisTransform.LookAt(Dest);

	}
}
