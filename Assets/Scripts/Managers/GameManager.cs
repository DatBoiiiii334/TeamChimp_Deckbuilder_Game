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

    public void Start(){
        PlayerTurn = true;
        _cardController = GetComponent<CardController>();
        GiveHand();
        //_player = GetComponent<Player>();
    }

    public void Update()
    {
        //
    }

    public void EndPlayerTurn(){
        PlayerTurn = false;
        GiveHand();
    }

    public void GiveHand(){
        //Remove old Cards 
        RemoveCards();

        //Give Mana to Player
        Player._instance.Mana = 5;

        //Add 5 new random cards
        for(int i = 0; i<5; i++ ){
            //Debug.Log("hi "+ i + "x");
            _cardController.BuyCard();
        }   
    }


    public void RemoveCards(){
        //Put all children from hand in a List
        var children = new List<GameObject>();
        foreach(Transform child in CardSpawn.transform) {
            children.Add(gameObject);
        }
        if (children.Count >= 0) {
            foreach (Transform child in CardSpawn.transform) {
                Destroy(child.gameObject);
            }
        }


        // kill each item in list
    }

    private void Awake(){
        if(_instance != null){
            Destroy(gameObject);
        }
        _instance = this;
    }
}
