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

    public Transform myCardLeft;
    public Transform myCardRight;

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
        List<PRS> originCardPRS = new List<PRS>();
        originCardPRS = RoundAlignment(myCardLeft, myCardRight, cardList.Count, 0.5f, Vector3.one * 3);

        for(int i = 0; i < cardList.Count; i++)
        {
            var card = cardList[i];

            card.originPRS = originCardPRS[i];
            card.MoveTransform(card.originPRS, true, 0.5f);
        }
    }

    private List<PRS> RoundAlignment(Transform leftTr, Transform rightTr, int objCount, float height, Vector3 scale)
    {
        float[] objLerps = new float[objCount];
        List<PRS> results = new List<PRS>(objCount);

        switch (objCount)
        {
            case 1: objLerps = new float[] { 0.5f }; break;
            case 2: objLerps = new float[] { 0.27f, 0.73f }; break;
            case 3: objLerps = new float[] { 0.1f, 0.5f, 0.9f }; break;//3개까지는 고정
            default:
                float interval = 1f / (objCount - 1);//그 외는 1을 ObjCount만큼으로 나눠 정렬
                for (int i = 0; i < objCount; i++)
                {
                    objLerps[i] = interval * i;
                }
                break;
        }

        for (int i = 0; i < objCount; i++)
        {
            var targetPos = Vector3.Lerp(leftTr.position, rightTr.position, objLerps[i]);
            var targetRot = Quaternion.identity;
            if(objCount >= 4)
            {
                float curve = Mathf.Sqrt(Mathf.Pow(height, 2) - Mathf.Pow(objLerps[i] - 0.5f, 2));
                curve = height >= 0 ? curve : -curve;
                targetPos.y += curve;
                targetRot = Quaternion.Slerp(leftTr.rotation, rightTr.rotation, objLerps[i]);
            }
            results.Add(new PRS(targetPos, targetRot, scale));
        }

        return results;
    }

}