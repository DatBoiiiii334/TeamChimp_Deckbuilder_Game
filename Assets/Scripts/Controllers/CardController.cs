using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController instance_CardController;
    public GameObject CardPrefab, CardSpawnPoint;
    public int intToSave;
    public string stringToSave;
    public List<Card> _PlayerCards;
    public Dictionary<Card, int> PlayerCards = new Dictionary<Card, int>();

    public void OGProfilesToDictioray(){
        foreach(Card profile in _PlayerCards){
            PlayerCards.Add(profile, 1);
        }
    }

    public void ProfilesToDictioray(){
        foreach(Card profile in _PlayerCards){
            PlayerCards.Add(profile, 2);
        }
    }

    public void BuyCard()
    {
        foreach (Card _card in PlayerCards.Keys)
        {
            for (int i = 0; i < PlayerCards.Values.Count; i++)
            {
                GameObject myCard;
                myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
                myCard.GetComponent<CardTemplate>().card = _card;
            }
        }
        // int index;

        // index = Random.Range(0, playerCardProfileDictionary.Count);
        // myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
        // myCard.GetComponent<CardTemplate>().card = playerCardProfileDictionary[AllCardProfiles[index].name];
        // CardSystemManager._instance.CardsInScene.Add(myCard);
    }

    private void Awake()
    {
        if (instance_CardController != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance_CardController = this;
        }
    }
}


