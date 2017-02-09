using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UsingDictonary : MonoBehaviour {

    public Dictionary<string, int> WordDatabase = new Dictionary<string, int>();

	// Use this for initialization
	void Start () {
        string[] Words = new string[5];
        Words[0] = "hello";
        Words[1] = "car";
        Words[2] = "today";
        Words[3] = "vehicle";
        Words[4] = "comuters";

        foreach (string Word in Words)
        {
            WordDatabase.Add(Word, Words.Length);
            // Пример
            // WordDatabase.Add("hello", 5);
        }
        Debug.Log("Score is: " + WordDatabase["hello"].ToString());
	}

}
