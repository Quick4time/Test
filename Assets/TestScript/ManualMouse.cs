using UnityEngine;
using System.Collections;

public class ManualMouse : MonoBehaviour {

    Collider Col = null;
    

	// Use this for initialization
	void Awake () {
        Col = GetComponent<Collider>();
        
	}

    void Start () {
        StartCoroutine(UpdateMouse());
    }
	// Попробовать изменить строчку 26-27 и переменные под 2D!!!!!!!!!! что бы работало сейчас работает некорректно.
    public IEnumerator UpdateMouse ()
    {
        bool bIntersected = false;
        bool bButtonDown = false;

        while(true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); ; //Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Col.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (!bIntersected)
                {
                    SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("Enter");
                }
                    bIntersected = true;
                if (!bButtonDown && Input.GetMouseButton(0))
                {
                    bButtonDown = true; SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
                    Debug.Log("On Button Down");
                }
                if (bButtonDown && !Input.GetMouseButton(0))
                {
                    if(bIntersected)
                    {
                        SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
                        Debug.Log("Exit");
                    }
                    bIntersected = false;
                    bButtonDown = false;
                }
            }
            yield return null;
        }
    }
}
