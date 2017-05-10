using UnityEngine;
using System.Collections;

public class PhysicsTest : MonoBehaviour {

    [SerializeField]
    string _objectName;

    //private Rigidbody2D _myRB;

    void Start()
    {
        //_myRB = GetComponent<Rigidbody2D>();
    }
	void Update ()
    {
        //Debug.Log("TestOcclusion");
        /*
        if (Input.GetKey(KeyCode.K))
        {
            _myRB.isKinematic = true;
        }
        else if (!Input.GetKey(KeyCode.K))
        {
            _myRB.isKinematic = false;
        }
        */
	}
    /*
    void OnBecameVisible()
    {
        //this.gameObject.SetActive(true);
        Debug.Log(string.Format("{0} became visible", _objectName));
        enabled = true;
    }
    void OnBecameInvisible()
    {
        //this.gameObject.SetActive(false);
        Debug.Log(string.Format("{0} became invisible", _objectName));
        enabled = false;
    }
    */
}
