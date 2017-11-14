using UnityEngine;

[ExecuteInEditMode]
public class ProximityDetector : MonoBehaviour
{
    [SerializeField]
    private Transform player;

	void Update ()
    {
        if (player != null)
        {
            GetComponent<Renderer>().sharedMaterial.SetVector("_PlayerPosition", player.position);
        }
	}
}
/*
Heres the code for anyone interested.Just use a canvas set to world space, a orthographic camera and a map UI texture. void Start () {
    SetZoom(117.41f);
}
void Update()
{
    MapCam.orthographicSize = Mathf.Clamp(MapCam.orthographicSize - (Input.GetAxis("Mouse ScrollWheel") != 0 ? Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")) : 0), minZoom, maxZoom);
}
void SetZoom(float zoomLevel)
{
    MapCam.orthographicSize = zoomLevel;
}
}
*/
