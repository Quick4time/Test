using UnityEngine;
using System.Collections;

public class ObjectPath : MonoBehaviour {

    GameObject target = null;
    public LayerMask LM;
    string tagenemy = "Enemy";

	void Start () {
        target = GameObject.FindGameObjectWithTag(tagenemy);
        LM = LayerMask.NameToLayer("Wall");
	}

	void Update () {
        if (!Physics2D.Linecast(transform.position, target.transform.position, LM))
        {
            //Debug.Log("Path Clear");
        }
	}
    /*void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, target.transform.position);
    }*/
}
