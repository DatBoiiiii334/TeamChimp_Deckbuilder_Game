using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystemManager : MonoBehaviour
{
    public static CardSystemManager _instance;
    public List<GameObject> CardPile = new List<GameObject>();
    public List<GameObject> DiscardPile = new List<GameObject>();
    public List<GameObject> CardDeck = new List<GameObject>();
    public enum cardsystem { MoveToCardPile, MoveToDiscardPile, MoveToCardDeck };
    public GameObject CardPilePos;
    public GameObject CardDiscardPilePos;
    public GameObject CardDeckPos;
    public float cardMoveSpeed;
    bool oby;
    int vv;
    public int switchValue { get; set; }


    public void AddCardToCardDeck(GameObject _card)
    {
        CardDeck.Add(_card);
        CardPile.Remove(_card);
        _card.transform.position = Vector2.Lerp(_card.transform.position, CardDeckPos.transform.position, cardMoveSpeed * Time.deltaTime);
        _card.GetComponent<Draggable>().parentToReturnTo = CardDeckPos.transform;
    }

    public void NExtCard(){
        vv += 1;
        AddCardToCardDeck(CardPilePos.transform.GetChild(vv).gameObject);
    }

    private void FixedUpdate()
    {
        
        AddCardToCardDeck(CardPilePos.transform.GetChild(0).gameObject);
    }






















    

    public void AddCardToCardPile(GameObject _card, Draggable _DragComp)
    {
        CardPile.Add(_card);
        _DragComp.parentToReturnTo = CardDiscardPilePos.transform;
        switchValue = 2;
    }

    public void AddCardToDiscardPile(GameObject _card, Draggable _DragComp)
    {
        DiscardPile.Add(_card);
        if (CardPile.Contains(_card)) { CardPile.Remove(_card); }
        _DragComp.parentToReturnTo = CardDiscardPilePos.transform;
        switchValue = 1;
    }

    public void SendFromDiscardToPile(GameObject _card)
    {
        CardPile.Add(_card);
        //if (DiscardPile.Contains(_card)) { DiscardPile.Remove(_card); }
        _card.GetComponent<Draggable>().parentToReturnTo = CardDiscardPilePos.transform;
    }

    public void SendEachCardToPile()
    {
        //StartCoroutine(WipeDiscardPile());
    }


    public void MoveCard(GameObject _card, GameObject destination)
    {
        _card.transform.position = Vector2.Lerp(_card.GetComponent<RectTransform>().position, destination.GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
    }

    public void MoveCards()
    {
        switch (switchValue)
        {
            case 1:
                foreach (GameObject usedCard in DiscardPile)
                {
                    usedCard.transform.position = Vector2.Lerp(usedCard.GetComponent<RectTransform>().position, CardDiscardPilePos.GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
                }
                break;

            case 2:
                foreach (GameObject usedCard in CardPile)
                {
                    usedCard.transform.position = Vector2.Lerp(usedCard.GetComponent<RectTransform>().position, CardPilePos.GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
                }
                break;

            case 3:
                foreach (GameObject usedCard in CardDeck)
                {
                    if (CardDeckPos.transform.childCount > 0)
                    {
                        Vector2 newCardPos = CardDeckPos.transform.GetChild(CardDeckPos.transform.childCount).GetComponent<RectTransform>().position;
                        usedCard.transform.position = Vector2.Lerp(usedCard.GetComponent<RectTransform>().position, CardDeckPos.transform.GetChild(CardDeckPos.transform.childCount).GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
                    }
                    else
                    {
                        usedCard.transform.position = Vector2.Lerp(usedCard.GetComponent<RectTransform>().position, CardDeckPos.transform.GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
                    }
                    //StartCoroutine(SendCardsToDeck());
                }
                break;
            case 4:
                break;

            default:
                break;
        }
    }

    // IEnumerator WipeDiscardPile()
    // {
    //     for (int i = 0; i < DiscardPile.Count; i++)
    //     {
    //         SendFromDiscardToPile(DiscardPile[i], DiscardPile[i].GetComponent<Draggable>());
    //     }
    //     yield return new WaitForSeconds(0.1f);
    //     DiscardPile.Clear();
    // }

    // IEnumerator SendCardsToDeck()
    // {
    //     yield return new WaitForSeconds(2f);
    //     switchValue = 4;
    // }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
