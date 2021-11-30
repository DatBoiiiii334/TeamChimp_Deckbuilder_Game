using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSystemManager : MonoBehaviour
{
    public static CardSystemManager _instance;
    public List<GameObject> CardsInScene = new List<GameObject>();

    public GameObject CardPilePos, CardDiscardPilePos, CardDeckPos;
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

    public void _MoveCardsToPile()
    {
        StartCoroutine(MoveCardsToPile());
    }

    public IEnumerator MoveCardsToPile()
    {
        foreach (Transform _card in GameManager._instance.CardSpawn.transform)
        {
            MoveToPile(_card.GetComponent<CardTemplate>(), 0.3f);
            yield return new WaitForSeconds(0.1f);
        }

        // foreach (GameObject _card in CardsInScene)
        // {
        //     MoveToPile(_card.GetComponent<CardTemplate>(), 0.3f);
        //     yield return new WaitForSeconds(0.1f);
        // }
    }

    public IEnumerator MoveCardsToDeck()
    {
        for (int i = 0; i < 5; i++)
        {
            int value;
            value = Random.Range(0, CardPilePos.transform.childCount);
            if (CardPilePos.transform.childCount > 0)
            {
                MoveToDeck(CardPilePos.transform.GetChild(i).GetComponent<CardTemplate>(), 0.3f);
                yield return new WaitForSeconds(0.1f);
            }
        }

        // foreach (GameObject _card in CardsInScene)
        // {
        //     MoveToDeck(_card.GetComponent<CardTemplate>(), 0.3f);
        //     yield return new WaitForSeconds(0.1f);
        // }
    }

    public IEnumerator MoveCardsToDiscard()
    {
        foreach (GameObject _card in CardsInScene)
        {
            MoveToDiscard(_card.GetComponent<CardTemplate>(), 0.3f);
            yield return new WaitForSeconds(0.1f);
        }
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
