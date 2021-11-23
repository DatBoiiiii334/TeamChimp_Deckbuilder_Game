using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystemManager : MonoBehaviour
{
    public static CardSystemManager _instance;
    public List<GameObject> CardsInScene = new List<GameObject>();

    public GameObject CardPilePos;
    public GameObject CardDiscardPilePos;
    public GameObject CardDeckPos;
    public float cardMoveSpeed;
    private float timer;

    public void MoveToPile(CardTemplate usedCard, float time)
    {
        StartCoroutine(usedCard.LerpPosition(CardPilePos, time));
    }
    public void MoveToDeck(CardTemplate usedCard, float time)
    {
        StartCoroutine(usedCard.LerpPosition(CardDeckPos, time));
    }
    public void MoveToDiscard(CardTemplate usedCard, float time)
    {
        StartCoroutine(usedCard.LerpPosition(CardDiscardPilePos, time));
    }

    private void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            print("Aplha1");
            StartCoroutine(MoveCardsToPile());
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            print("Aplha2");
            StartCoroutine(MoveCardsToDeck());
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            print("Aplha3");
            StartCoroutine(MoveCardsToDiscard());
        }
    }

    public IEnumerator MoveCardsToPile()
    {
        // MoveToPile(usedCard, 0.5f);
        MoveToPile(CardsInScene[0].GetComponent<CardTemplate>(), 0.3f);
        yield return new WaitForSeconds(0.1f);
        MoveToPile(CardsInScene[1].GetComponent<CardTemplate>(), 0.3f);
        yield return new WaitForSeconds(0.1f);
        MoveToPile(CardsInScene[2].GetComponent<CardTemplate>(), 0.3f);
        yield return new WaitForSeconds(0.1f);
        MoveToPile(CardsInScene[3].GetComponent<CardTemplate>(), 0.3f);
        yield return new WaitForSeconds(0.1f);
        MoveToPile(CardsInScene[4].GetComponent<CardTemplate>(), 0.3f);
        //yield return new WaitForSeconds(0.1f);
    }

    public IEnumerator MoveCardsToDeck()
    {
        MoveToDeck(CardsInScene[0].GetComponent<CardTemplate>(), 0.3f);
        yield return new WaitForSeconds(0.1f);
        MoveToDeck(CardsInScene[1].GetComponent<CardTemplate>(), 0.3f);
        yield return new WaitForSeconds(0.1f);
        MoveToDeck(CardsInScene[2].GetComponent<CardTemplate>(), 0.3f);
        yield return new WaitForSeconds(0.1f);
        MoveToDeck(CardsInScene[3].GetComponent<CardTemplate>(), 0.3f);
        yield return new WaitForSeconds(0.1f);
        MoveToDeck(CardsInScene[4].GetComponent<CardTemplate>(), 0.3f);
    }

    public IEnumerator MoveCardsToDiscard()
    {
        MoveToPile(CardsInScene[0].GetComponent<CardTemplate>(), 0.5f);
        yield return new WaitForSeconds(0.1f);
        MoveToPile(CardsInScene[1].GetComponent<CardTemplate>(), 0.5f);
        yield return new WaitForSeconds(0.1f);
        MoveToPile(CardsInScene[2].GetComponent<CardTemplate>(), 0.5f);
        yield return new WaitForSeconds(0.1f);
        MoveToPile(CardsInScene[3].GetComponent<CardTemplate>(), 0.5f);
        yield return new WaitForSeconds(0.1f);
        MoveToPile(CardsInScene[4].GetComponent<CardTemplate>(), 0.5f);
    }


    // public void AddCardToCardDeck(GameObject _card)
    // {
    //     CardDeck.Add(_card);
    //     CardPile.Remove(_card);
    //     _card.transform.position = Vector2.Lerp(_card.transform.position, CardDeckPos.transform.position, cardMoveSpeed * Time.deltaTime);
    //     _card.GetComponent<Draggable>().parentToReturnTo = CardDeckPos.transform;
    // }

    // public void AddCardToCardPile(GameObject _card, Draggable _DragComp)
    // {
    //     CardPile.Add(_card);
    //     _DragComp.parentToReturnTo = CardDiscardPilePos.transform;
    //     switchValue = 2;
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
