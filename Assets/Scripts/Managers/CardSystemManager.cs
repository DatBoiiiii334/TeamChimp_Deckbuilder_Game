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

    private void FixedUpdate() {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            print("Aplha1");
            foreach(GameObject _Card in CardsInScene){
               StartCoroutine(MoveCardsToPile(_Card.GetComponent<CardTemplate>()));
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha2)){
            print("Aplha2");
            foreach(GameObject _Card in CardsInScene){
               StartCoroutine(MoveCardsToDeck(_Card.GetComponent<CardTemplate>()));
            }
        }   

        if(Input.GetKeyDown(KeyCode.Alpha3)){
            print("Aplha3");
            foreach(GameObject _Card in CardsInScene){
               StartCoroutine(MoveCardsToDiscard(_Card.GetComponent<CardTemplate>()));
            }
        }        
    }

    IEnumerator MoveCardsToPile(CardTemplate usedCard){
        MoveToPile(usedCard, 0.5f);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator MoveCardsToDeck(CardTemplate usedCard){
        MoveToDeck(usedCard, 0.5f);
        yield return new WaitForSeconds(0.1f);
    }

    IEnumerator MoveCardsToDiscard(CardTemplate usedCard){
        MoveToDiscard(usedCard, 0.5f);
        yield return new WaitForSeconds(0.1f);
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
