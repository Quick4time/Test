using UnityEngine;
using System.Collections;

public class AllDistroyTest : MonoBehaviour, IUpdateableObject {

    void Start()
    {
        GameLogic.Instance.RegisterUpdateableObject(this);
    }
	public void OnUpdate (float dt)
    {
	    if (Input.GetKeyDown(KeyCode.V))
        {
            DestroyImmediate(this.gameObject);
        }
	}
    public void OnDestroy() // при уничтожении обьекта
    {
        if (GameLogic.IsAlive)
        {
            GameLogic.Instance.DeregisterUpdateableObject(this);
        }
        //Debug.Log("Script was Destroy; ");
    }
    /*
    // Kills the game object
Destroy(gameObject);

// Removes this script instance from the game object
Destroy(this);

// Removes the rigidbody from the game object
Destroy(rigidbody);

// Kills the game object in 5 seconds after loading the object
Destroy(gameObject, 5);

    // When the user presses Ctrl, it will remove the script 
    // named FooScript from the game object
    void Update()
    {
        if (Input.GetButton("Fire1") && GetComponent<FooScript>())
        {
            Destroy(GetComponent<FooScript>());
        }
    }*/
}
