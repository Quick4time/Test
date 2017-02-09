using UnityEngine;
using System.Collections;

public class Lerp : MonoBehaviour {

    public Transform player;
    public Transform enemy;
    public float speed = 1.0f;
    private float startTime;
    private float journeyLength;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        journeyLength = Vector3.Distance(player.position, enemy.position);

	}
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(player.position, enemy.position, fracJourney);
	}
}
