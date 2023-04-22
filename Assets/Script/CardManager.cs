using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Transform cardParent;

    public List<Card> cardList = new List<Card>(10);

    public Card originCard;

    [SerializeField]
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
            AddCard();
        }
    }

    private void AddCard()
    {
        Card card = Instantiate(originCard, cardParent.position,Quaternion.identity);
        card.transform.SetParent(cardParent);

        cardList.Add(card);
        CardCount++;

        CardAlignment();
    }

    private void CardPositionSort()
    {
        
    }

    private void CardAlignment()
    {
        var targetCard = cardList;

        for(int i = 0; i < cardList.Count; i++)
        {
            var card = cardList[i];

            card.originPRS = new PRS(Vector3.zero, Quaternion.identity, card.transform.localScale);
            card.MoveTransform(card.originPRS, true, 0.5f);
        }
    }

}