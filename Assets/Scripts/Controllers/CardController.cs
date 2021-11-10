using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController instance_CardController;
    public GameObject CardPrefab, CardSpawnPoint;
    public int intToSave;
    public string stringToSave;
    public List<Card> AllCardProfiles;

    [SerializeField]
    public Dictionary<string, Card> playerCardProfileDictionary = new Dictionary<string, Card>();

    public void Start()
    {
        for (int i = 0; i < AllCardProfiles.Count; i++)
        {
            playerCardProfileDictionary.Add(AllCardProfiles[i].name, AllCardProfiles[i]);
        }
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

    public void SpawnCard()
    {
        for (int i = 0; i < AllCardProfiles.Count; i++)
        {
            GameObject myCard;
            myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
            myCard.GetComponent<CardTemplate>().card = AllCardProfiles[i];
        }
    }

    public void BuyCard()
    {
        int index;
        //int cardId = playerCardProfileDictionary.ElementAt(index).Key;
        //int cardObject = playerCardProfileDictionary.ElementAt(index).Value;
        GameObject myCard;
        //randomvalue = Random.Range(0, AllCardProfiles.Count);
        //myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
        //myCard.GetComponent<CardTemplate>().card = AllCardProfiles[randomvalue];
        index = Random.Range(0, playerCardProfileDictionary.Count);
        myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
        myCard.GetComponent<CardTemplate>().card = playerCardProfileDictionary[AllCardProfiles[index].name];
    }

    
}


