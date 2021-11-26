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

    private void FixedUpdate()
    {
        // if (Input.GetKeyDown(KeyCode.Alpha1))
        // {
        //     print("Aplha1");
        //     StartCoroutine(MoveCardsToPile());
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha2))
        // {
        //     print("Aplha2");
        //     StartCoroutine(MoveCardsToDeck());
        // }

        // if (Input.GetKeyDown(KeyCode.Alpha3))
        // {
        //     print("Aplha3");
        //     StartCoroutine(MoveCardsToDiscard());
        // }
    }

    public IEnumerator MoveCardsToPile()
    {
        // foreach (GameObject _card in CardsInScene)
        // {
        //     MoveToPile(_card.GetComponent<CardTemplate>(), 0.3f);
        //     yield return new WaitForSeconds(0.1f);
        //     // for loop check if 0
        // }
        
        for(int i = 0; i < 5; i++){
            //MoveToPile(CardController.instance_CardController.CardSpawnPoint.transform.GetChild(i).GetComponent<CardTemplate>(), 0.3f);
            //print("Amount: "+ GameManager._instance.amountCardsSpawn);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public IEnumerator MoveCardsToDeck()
    {
        foreach (GameObject _card in CardsInScene)
        {
            MoveToDeck(_card.GetComponent<CardTemplate>(), 0.3f);
            yield return new WaitForSeconds(0.1f);
        }
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
