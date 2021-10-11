using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy : Humanoid
{

    public static Enemy _instance;
    public int basicDamage, SpecialDamage, HealAmount, ShieldAmount;
    public TextMeshProUGUI NextEnemyAttack;
    private Animator enemyAnimator;

    private int myNextAttack;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        _instance = this;

        EnemyTurn();
    }

    public void Start(){
        //EnemyTurn();
        enemyAnimator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (GameManager._instance.PlayerTurn == false)
        {
            EnemyAttackTurn();
        }
        NameField.text = Name;
        HealthField.text = Health.ToString();
        ShieldField.text = Shield.ToString();
        //NextEnemyAttack.text = 
    }

    public void EnemyTurn()
    {
        //GameManager._instance.PlayerTurn = true;
        int randomvalue;
        randomvalue = Random.Range(0, 4);
        myNextAttack = randomvalue;
        switch (randomvalue)
        {
            case 0: //Basic attack
                ShowNextAttack("Basic Attack");
                break;

            case 1: //Heal self
                ShowNextAttack("Healing self");
                break;

            case 2: //Special attack
                ShowNextAttack("Special Attack");
                break;

            case 3: // Shield self
                ShowNextAttack("Shield self");
                break;

            default: //Something must went wrong
                Debug.Log("Something went wrong, no case selected");
                break;
        }
    }

    public void ShowNextAttack(string nameAttack){
        NextEnemyAttack.text = nameAttack;
    }

    public void EnemyAttackTurn(){
        GameManager._instance.PlayerTurn = true;
        

        switch(myNextAttack){
            case 0:
            ComidAttack(basicDamage, "Basic Attack");
            EnemyTurn();
            break;

            case 1:
            StartCoroutine(EnemyDoAttack("Heal"));
            Enemy._instance.Health += HealAmount;
            //Debug.Log(gameObject.name + " Has healt himself");
            EnemyTurn();
            break;

            case 2:
            ComidAttack(SpecialDamage, "Special Attack");
            EnemyTurn();
            break;

            case 3:
            StartCoroutine(EnemyDoAttack("Heal"));
            Enemy._instance.Shield += ShieldAmount;
            //Debug.Log(gameObject.name + " Has shield himself");
            EnemyTurn();
            break;

            default:
            Debug.Log("Something went wrong");
            break;
        }
    }

    public void ComidAttack(int damage, string call)
    {
        if (Player._player.Shield >= damage)
        {
            //PLAY COMBAT ANIMATION
            StartCoroutine(EnemyDoAttack("BasicAttack"));
            Player._player.Shield -= damage;
            //Debug.Log(gameObject.name + " did a " + call + " It was absorbed by shield.");
        }
        else if (Player._player.Shield < damage)
        {
            int var;
            //PLAY COMBAT ANIMATION
            StartCoroutine(EnemyDoAttack("BasicAttack"));
            var = damage -= Player._player.Shield;
            Player._player.Health -= var;
            //Debug.Log(gameObject.name + " did a " + call + " that broke through the players shield");
        }
    }

    IEnumerator EnemyDoAttack(string whatDo){
        enemyAnimator.SetBool(whatDo, true);
        yield return new WaitForSeconds(0.1f);
        enemyAnimator.SetBool(whatDo, false);
        StopAllCoroutines();
    }
}
