using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject CardSpawn;
    public bool PlayerTurn;
    private CardController _cardController;
    //private Player _player;
    //private Player _player;

    public void Start()
    {
        PlayerTurn = true;
        _cardController = GetComponent<CardController>();
        GiveHand();
    }


    public void EndPlayerTurn()
    {
        PlayerTurn = false;
        GiveHand();
    }

    public void GiveHand()
    {
        //Remove old Cards 
        RemoveCards();

        //Give Mana to Player
        Player._player.Mana = 5;

        //Add 5 new random cards
        for (int i = 0; i < 5; i++)
        {
            _cardController.BuyCard();
        }
    }


    public void RemoveCards()
    {
        var children = new List<GameObject>();
        foreach (Transform child in CardSpawn.transform)
        {
            children.Add(gameObject);
        }
        if (children.Count >= 0)
        {
            foreach (Transform child in CardSpawn.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;
    }
}
