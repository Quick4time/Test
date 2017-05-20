using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    GameObject player;
    Rigidbody2D rb2d;
    Vector2 velocity;
    float speed = 3.0f;

	void Start ()
    {
        player = gameObject;
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	void Update ()
    {
        
	}
}
