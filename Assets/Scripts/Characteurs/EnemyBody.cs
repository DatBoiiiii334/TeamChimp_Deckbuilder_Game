using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyBody : MonoBehaviour
{
    public static EnemyBody _instanceEnemyBody;
    public EnemyCore _core;
    public TextMeshProUGUI nameField, shieldField, NextEnemyAttack;
    public Slider hpSlider;
    public Animator myAnimator;
    public int Health, Shield;

    //public static Enemy _instance;
    /* Refernces will happen by looking at either the enemy TAG or CLASS */

    //public int basicDamage, SpecialDamage, HealAmount, ShieldAmount;
    //public TextMeshProUGUI NextEnemyAttack;
    //public Slider EnemyHpSlider, EnemyShieldSlider;
    //private Animator enemyAnimator;

    private void Awake()
    {
        if (_instanceEnemyBody != null)
        {
            Destroy(gameObject);
        }
        _instanceEnemyBody = this;

        EnemyTurn();
    }

    private int myNextAttack;

    public void Start()
    {
        nameField.text = _core.Name;
        Health = _core.maxHealth;
        Shield = _core.maxShield;
        //myAnimator = _core.animController;
        myAnimator = GetComponent<Animator>();
        hpSlider.maxValue = _core.maxHealth;
    }

    public void Update()
    {
        hpSlider.value = Health;
        shieldField.text = Shield.ToString();

        if (GameManager._instance.PlayerTurn == false)
        {
            EnemyAttackTurn();
        }
    }

    public void EnemyTurn()
    {
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

    public void ShowNextAttack(string nameAttack)
    {
        NextEnemyAttack.text = nameAttack;
    }

    public void EnemyAttackTurn()
    {
        GameManager._instance.PlayerTurn = true;


        switch (myNextAttack)
        {
            case 0:
                ComidAttack(_core.basicAttack, "Basic Attack");
                EnemyTurn();
                break;

            case 1:
                ComidRegen(_core.maxBuff, 0);
                EnemyTurn();
                break;

            case 2:
                ComidAttack(_core.specialAttack, "Special Attack");
                EnemyTurn();
                break;

            case 3:
                ComidRegen(0, _core.maxBuff);
                EnemyTurn();
                break;

            default:
                Debug.Log("Something went wrong");
                break;
        }
    }

    public void ComidRegen(int heal, int shield)
    {
        StartCoroutine(EnemyDoAttack("Heal"));
        EnemyBody._instanceEnemyBody.Shield += shield;
        EnemyBody._instanceEnemyBody.Health += heal;
    }

    public void ComidAttack(int damage, string call)
    {
        if (Player._player.Shield >= damage)
        {
            //PLAY COMBAT ANIMATION
            StartCoroutine(EnemyDoAttack("BasicAttack"));
            Player._player.Shield -= damage;
        }
        else if (Player._player.Shield < damage)
        {
            int var;
            //PLAY COMBAT ANIMATION
            StartCoroutine(EnemyDoAttack("BasicAttack"));
            var = damage -= Player._player.Shield;
            Player._player.Health -= var;
            Player._player.Shield = 0;
            if (Player._player.Health <= 0)
            {
                GameManager._instance.LoseScreen.SetActive(true);
            }
        }
    }

    IEnumerator EnemyDoAttack(string whatDo)
    {
        myAnimator.SetBool(whatDo, true);
        yield return new WaitForSeconds(0.1f);
        myAnimator.SetBool(whatDo, false);
        StopAllCoroutines();
    }
}
