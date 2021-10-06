using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Humanoid { 

    public static Enemy _instance;
    public int basicDamage;
    public int SpecialDamage;
    public int HealAmount;
    public int ShieldAmount;

    private void Awake(){
        if(_instance != null){
            Destroy(gameObject);
        }
        _instance = this;
    }

    public void Update()
    {
        if(GameManager._instance.PlayerTurn == false){
            EnemyTurn();
        }
        NameField.text = Name;
        HealthField.text = Health.ToString();
        ShieldField.text = Shield.ToString();
    }

    public void EnemyTurn(){
        GameManager._instance.PlayerTurn = true;
        Debug.Log("Your turn");

        int randomvalue;
        randomvalue = Random.Range(0, 4);
        switch(randomvalue){
            
            case 0:
                //Basic Attack
                if(Player._instance.Shield >= basicDamage){
                    Player._instance.Shield -= basicDamage;
                    Debug.Log(gameObject.name + " did a Basic attack");
                }else if(Player._instance.Shield < basicDamage){
                        int var;
                        var = basicDamage -= Player._instance.Shield;
                        Player._instance.Health -= var;
                        Debug.Log(gameObject.name + " did a Basic attack that broke through shield");
                   }
                
            break;

            case 1:
                //Heal yourself
                Enemy._instance.Health += HealAmount;
                Debug.Log(gameObject.name + " Has healt himself");
            break;

            case 2:
                //Special Attack
                Player._instance.Health -= SpecialDamage;
                Debug.Log(gameObject.name + " did a Special attack");
            break;

            case 3:
                //Shield yourself
                Enemy._instance.Shield += ShieldAmount;
                Debug.Log(gameObject.name + " Has shield himself");
            break;

            default:
            break;


        }
    }

    
}
