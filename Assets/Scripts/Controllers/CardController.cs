using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    public static CardController instance_CardController;
    public GameObject CardPrefab, CardSpawnPoint;
    public List<Card> AllCardProfiles;
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
        int randomvalue;
        GameObject myCard;
        randomvalue = Random.Range(0, AllCardProfiles.Count);
        myCard = Instantiate(CardPrefab, CardSpawnPoint.transform);
        myCard.GetComponent<CardTemplate>().card = AllCardProfiles[randomvalue];
    }
}
