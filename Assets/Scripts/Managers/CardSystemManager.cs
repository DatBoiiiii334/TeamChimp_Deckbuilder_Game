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
    public int switchValue { get; set; }

    public void AddCardToCardDeck(GameObject _card, Draggable _DragComp)
    {
        if (CardController.instance_CardController.CardSpawnPoint.transform.childCount == 0)
        {
            _DragComp.parentToReturnTo = CardController.instance_CardController.CardSpawnPoint.transform;
        }
        CardDeck.Add(_card);
        switchValue = 3;
        //_DragComp.parentToReturnTo = CardDeckPos.transform;
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

    public void SendFromDiscardToPile(GameObject _card, Draggable _DragComp)
    {
        CardPile.Add(_card);
        //if (DiscardPile.Contains(_card)) { DiscardPile.Remove(_card); }
        _DragComp.parentToReturnTo = CardDiscardPilePos.transform;
    }

    public void SendEachCardToPile()
    {
        StartCoroutine(WipeDiscardPile());
    }

    private void FixedUpdate()
    {
        MoveCards();
        // foreach (GameObject usedCard in DiscardPile)
        // {
        //     usedCard.transform.position = Vector2.Lerp(usedCard.GetComponent<RectTransform>().position, CardDiscardPilePos.GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
        // }

        // foreach (GameObject usedCard in CardPile)
        // {
        //     usedCard.transform.position = Vector2.Lerp(usedCard.GetComponent<RectTransform>().position, CardPilePos.GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
        // }

        // foreach (GameObject usedCard in CardDeck)
        // {
        //     if (CardDeckPos.transform.childCount > 0)
        //     {
        //         Vector2 newCardPos = CardDeckPos.transform.GetChild(CardDeckPos.transform.childCount).GetComponent<RectTransform>().position;
        //         usedCard.transform.position = Vector2.Lerp(usedCard.GetComponent<RectTransform>().position, CardDeckPos.transform.GetChild(CardDeckPos.transform.childCount).GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
        //     }
        //     else
        //     {
        //         usedCard.transform.position = Vector2.Lerp(usedCard.GetComponent<RectTransform>().position, CardDeckPos.transform.GetComponent<RectTransform>().position, cardMoveSpeed * Time.deltaTime);
        //     }
        // }
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
                }
                break;

            default:
                break;
        }
    }

    IEnumerator WipeDiscardPile()
    {
        for (int i = 0; i < DiscardPile.Count; i++)
        {
            SendFromDiscardToPile(DiscardPile[i], DiscardPile[i].GetComponent<Draggable>());
        }
        yield return new WaitForSeconds(0.1f);
        DiscardPile.Clear();
    }

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
