using UnityEngine;
using System.Collections;

public class cam_itween_mover : MonoBehaviour {

    public float Time = 15f;

	// Use this for initialization
	void Start () {
        iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("New Path 1"), "time", Time, "easetype", iTween.EaseType.easeInOutSine));
	}

}
