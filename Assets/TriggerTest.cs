using UnityEngine;
using System.Collections;

public class TriggerTest : MonoBehaviour {
    /*
    [SerializeField]
    Collider2D _Col;
    GameObject LeftObj;
    GameObject RightObj;
    */
    public 
    Rigidbody2D _RB2D;

	void Start ()
    {
        _RB2D = GetComponent<Rigidbody2D>();
        /*
        _Col = GetComponent<Collider2D>();
        LeftObj = GameObject.FindGameObjectWithTag("LeftCollide");
        RightObj = GameObject.FindGameObjectWithTag("RightCollide");
        */	
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("LeftCollide"))
        {
            Debug.Log("LeftColEnt");
        }
        else if (col.gameObject.CompareTag("RightCollide"))
        {
            Debug.Log("RightColEnt");
        }
        /*
        if (col.gameObject.CompareTag("LeftCollide"))
        {
            Debug.Log("EnterLeft");
        }
        else if (col.gameObject.CompareTag("RightCollide"))
        {
            Debug.Log("EnterRight");
        }
        */
    }
    void OnTriggerStay2D(Collider2D col)
    {
            _RB2D.sleepMode = RigidbodySleepMode2D.NeverSleep;
            if (col.gameObject.CompareTag("LeftCollide"))
            {
                Debug.Log("LeftColStay");
            }
            else if (col.gameObject.CompareTag("RightCollide"))
            {
                Debug.Log("RightColStay");
            }
        /*
        if (col.gameObject.CompareTag("LeftCollide"))
        {ц
            Debug.Log("StayLeft");
        }
        else if (col.gameObject.CompareTag("RightCollide"))
        {
            Debug.Log("StayRight");
        }
        */
    }
    void OnTriggerExit2D(Collider2D col)
    {
        _RB2D.sleepMode = RigidbodySleepMode2D.StartAwake;
        if (col.gameObject.CompareTag("LeftCollide"))
        {
            Debug.Log("LeftColEx");
        }
        else if (col.gameObject.CompareTag("RightCollide"))
        {
            Debug.Log("RightColEx");
        }

        /*
        if (col.gameObject.CompareTag("LeftCollide"))
        {
            Debug.Log("StayLeft");
        }
        else if (col.gameObject.CompareTag("RightCollide"))
        {
            Debug.Log("StayRight");
        }
        */
    }
}
