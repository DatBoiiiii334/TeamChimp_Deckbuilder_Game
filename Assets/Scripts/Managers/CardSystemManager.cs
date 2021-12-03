using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystemManager : MonoBehaviour
{
    public static CardSystemManager _instance;
    public List<GameObject> CardsInScene = new List<GameObject>();

    public GameObject CardPilePos, CardDiscardPilePos, CardDeckPos, CardSpawnPoint;
    public int AmountCardsInPLayerHand;
    public float cardMoveSpeed;
    private float timer;

    public void _MoveCardsSpawnedCards()
    {
        StartCoroutine(MoveCards(CardPilePos.transform, CardSpawnPoint));
    }

    public void _MoveCardsToDiscard(Transform _card)
    {
        StartCoroutine(MoveToDiscard(_card));
    }

    public void _MoveCardsToPile(Transform _card)
    {
        StartCoroutine(MoveCardsToPile(_card));
    }

    public void _MoveCardsToDeck()
    {
        StartCoroutine(MoveToDeck());
    }

    public void ResetCards()
    {
        StartCoroutine(ResetPile());
    }

    public IEnumerator MoveCardsToPile(Transform _card)
    {
        StartCoroutine(LerpCardPosition(CardPilePos.transform, 0.3f, _card));
        yield return new WaitForSeconds(0.3f);
        _card.SetParent(CardPilePos.transform);
    }

    public IEnumerator MoveToDiscard(Transform _card)
    {
        StartCoroutine(LerpCardPosition(CardDiscardPilePos.transform, 0.3f, _card));
        yield return new WaitForSeconds(0.3f);
        _card.SetParent(CardDiscardPilePos.transform);
    }

    public IEnumerator ResetPile(){
        for (int i = 0; i < CardDiscardPilePos.transform.childCount; i++)
        {
            print("ResetPile Activated");
            StartCoroutine(LerpCardPosition(CardPilePos.transform, 0.1f, CardDiscardPilePos.transform.GetChild(i)));
            yield return new WaitForSeconds(0.1f);
            //CardDiscardPilePos.transform.GetChild(i).SetParent(CardPilePos.transform);
            yield return null;
        }
    }

    public IEnumerator MoveToDeck()
    {
        for (int i = 0; i < AmountCardsInPLayerHand; i++)
        {
            int randomVar = Random.Range(0, CardPilePos.transform.childCount);
            StartCoroutine(LerpCardPosition(CardDeckPos.transform, 0.3f, CardPilePos.transform.GetChild(randomVar)));
            //print("randomVar: " + randomVar);
            yield return new WaitForSeconds(0.3f);
            CardPilePos.transform.GetChild(randomVar).SetParent(CardDeckPos.transform);
            yield return null;
        }
    }

    public IEnumerator MoveCards(Transform tragetPos, GameObject currentPos)
    {
        for (int i = 0; i < currentPos.transform.childCount; i++)
        {
            StartCoroutine(LerpCardPosition(tragetPos, 0.3f, currentPos.transform.GetChild(i)));
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator LerpCardPosition(Transform targetPosition, float duration, Transform currentCardPosition)
    {
        float time = 0;
        Vector2 startPosition = currentCardPosition.position;

        while (time < duration)
        {
            currentCardPosition.position = Vector2.Lerp(startPosition, targetPosition.transform.position, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        currentCardPosition.position = targetPosition.transform.position;
        //currentCardPosition.SetParent(targetPosition.transform);
    }

    public IEnumerator MoveCardsToDeck()
    {
        print("I am getting lunch");
        // int value;
        // value = Random.Range(0, CardPilePos.transform.childCount);
        // for (int i = 0; i <= 5; i++)
        // {
        //     MoveCards(CardPilePos.transform.GetChild(i).GetComponent<CardTemplate>(), 0.3f, CardDeckPos);
        yield return new WaitForSeconds(0.1f);
        // }
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
