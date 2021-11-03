using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject CardSpawn, winScreen, LoseScreen;
    public bool PlayerTurn;
    //Player stats 
    public int playerHp, playerShield, playerMana;
    public int enemyHp, enemeyShield, enemyLastDamageTaken;


    private CardController _cardController;

    public void Start()
    {
        PlayerTurn = true;
        _cardController = GetComponent<CardController>();
        GiveHand();
    }

    public void EndPlayerTurn()
    {
        if (EnemyBody._instanceEnemyBody.Health <= 0)
        {
            winScreen.SetActive(true);
            CardPicker.instance_CardPicker.OpenNewCardsWindow();
        }
        else
        {
            PlayerTurn = false;
            EnemyBody._instanceEnemyBody.UpdateEnemyUI();
            GiveHand();
        }
    }

    public void GiveHand()
    {
        //Remove old Cards 
        RemoveCards(CardSpawn.transform);

        //Give Mana to Player
        Player._player.Mana = 5;
        Player._player.UpdatePlayerUI();

        //Add 5 new random cards
        for (int i = 0; i < 5; i++)
        {
            _cardController.BuyCard();
        }
    }


    public void RemoveCards(Transform cardSpawn)
    {
        var children = new List<GameObject>();
        foreach (Transform child in cardSpawn)
        {
            children.Add(gameObject);
        }
        if (children.Count >= 0)
        {
            foreach (Transform child in cardSpawn)
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
