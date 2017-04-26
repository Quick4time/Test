using UnityEngine;
using System.Collections;

public class cam_itween_mover : MonoBehaviour {


    public float Time = 15f;

    // Use this for initialization
    void Update () {

        //iTween.MoveFrom(gameObject, iTween.Hash("path", iTweenPath.GetPath("New Path 1"), "time", Time, "easetype", iTween.EaseType.easeInOutSine));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("New Path 1"), "time", Time, "easetype", iTween.EaseType.easeInOutSine));
        }
        
	}

}
