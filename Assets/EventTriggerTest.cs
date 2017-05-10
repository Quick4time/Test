using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventTriggerTest : MonoBehaviour {

    public enum Direction {North, East, South, West };
    public Direction myDir;

    Image image;
    Color[] RandomColor = new Color[6];
    [SerializeField]
    TMPro.TextMeshProUGUI text;

    private void Start()
    {
        image = GetComponent<Image>();
        RandomColor[0] = new Color(225.0f, 0.0f, 0.0f);
        RandomColor[1] = new Color(225.0f, 225.0f, 0.0f);
        RandomColor[2] = new Color(0.0f, 225.0f, 0.0f);
        RandomColor[3] = new Color(0.0f, 225.0f, 225.0f);
        RandomColor[4] = new Color(0.0f, 0.0f, 225.0f);
        RandomColor[5] = new Color(225.0f, 0.0f, 225.0f);
        RandomColor[6] = new Color(0.0f, 225.0f, 150.0f);
    }

    public void EightBlue()
    {
        image.color = RandomColor[Random.Range(0, RandomColor.Length)]; //Random.ColorHSV(0.0f, 1.0f, 1.0f, 1.0f, 0.5f, 1.0f); Рандомные цвета HSV.
    }
    public void EightWhite()
    {
        image.color = new Color (255.0f, 255.0f, 255.0f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(myDir)
            {
                case Direction.North:
                    Debug.Log("North");
                    text.text = myDir.ToString();
                    break;
                case Direction.South:
                    Debug.Log("South");
                    text.text = myDir.ToString();
                    break;
                case Direction.East:
                    Debug.Log("East");
                    text.text = myDir.ToString();
                    break;
                case Direction.West:
                    Debug.Log("West");
                    text.text = myDir.ToString();
                    break;
            }
        }
    }

    IEnumerator Dir()
    {
        Direction myDir;

        while(true)
        {
            myDir = Direction.North;
            yield return new WaitForSeconds(2.0f);
            myDir = Direction.South;
            yield return new WaitForSeconds(2.0f);
            myDir = Direction.East;
            yield return new WaitForSeconds(2.0f);
            myDir = Direction.West;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch(col.tag)
        {
            case "RedRing":
                break;
            case "GreenRing":
                break;
            case "YellowRing":
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        switch(col.gameObject.tag)
        {
            case "RedRing":
                break;
            case "Greenring":
                break;
            case "YellowRing":
                break;
        }
    }
}
