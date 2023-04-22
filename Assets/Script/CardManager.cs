using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Transform cardParent;

    public List<Card> cardList = new List<Card>(10);

    public Card originCard;

    private int cardCount;

    public int CardCount 
    {
        get => cardCount;
        set
        {
            cardCount = value;

            //정렬 함수
        }
    }
    void Start()
    {

    }

    void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Card card = Instantiate(originCard, cardParent);
            cardList.Add(card);
        }
    }

    private void AddCard()
    {
        Card card = Instantiate(originCard, cardParent);
        cardList.Add(card);
        CardCount++;
    }

    private void CardPositionSort()
    {
        
    }

}
