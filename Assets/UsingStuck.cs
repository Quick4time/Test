using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class PlayingCard
{
    public string Name;
    public int Attack;
    public int Defense;
}
public class UsingStuck : MonoBehaviour {

    public Stack<PlayingCard> CardStuck = new Stack<PlayingCard>();
	
	void Start () {
        PlayingCard[] Cards = new PlayingCard[5];

        for (int i = 0; i < 5; i++)
        {
            Cards[i] = new PlayingCard();
            Cards[i].Name = "Cards_" + i.ToString();
            Cards[i].Attack = Cards[i].Defense = i * 3;
            CardStuck.Push(Cards[i]);
        }
        
        while(CardStuck.Count > 1)
        {
            PlayingCard PickedCard = CardStuck.Pop();
            Debug.Log(PickedCard.Name);
        }
	
	}
}
