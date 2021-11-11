using System.Collections;
using UnityEngine;

public class EnemyTurnState : State
{
    public static EnemyTurnState _enemyTurnInstance;
    public GameObject CardDeckBlocker;
    public int enemyState, myNextAttack;

    public override void Enter()
    {
        print("EnemyTurnState");
        CardDeckBlocker.SetActive(true);
        StartCoroutine(ShowEnemyTurn());
    }

    public override void Exit()
    {}

    public void EnemyAttackTurn()
    {
        UIManager._instanceUI.UIBanner.SetActive(false);
        switch (EnemyBody._instanceEnemyBody.myNextAttack)
        {
            case 0:
                ComidAttack(EnemyBody._instanceEnemyBody._core.basicAttack, "Basic Attack");
                EnemyBody._instanceEnemyBody.EnemyTurn();
                StartCoroutine(GoToNextState());
                break;

            case 1:
                ComidRegen(EnemyBody._instanceEnemyBody._core.maxBuff, 0);
                EnemyBody._instanceEnemyBody.EnemyTurn();
                StartCoroutine(GoToNextState());
                break;

            case 2:
                ComidAttack(EnemyBody._instanceEnemyBody._core.specialAttack, "Special Attack");
                EnemyBody._instanceEnemyBody.EnemyTurn();
                StartCoroutine(GoToNextState());
                break;

            case 3:
                ComidRegen(0, EnemyBody._instanceEnemyBody._core.maxBuff);
                EnemyBody._instanceEnemyBody.EnemyTurn();
                StartCoroutine(GoToNextState());
                break;

            case 4:
                //Doe feared animatie en sound design
                EnemyBody._instanceEnemyBody.EnemyTurn();
                StartCoroutine(GoToNextState());
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
            StartCoroutine(EnemyDoAttack("BasicAttack"));
            Player._player.Shield -= damage;
            Player._player.UpdatePlayerUI();
        }
        else if (Player._player.Shield < damage)
        {
            int var;
            StartCoroutine(EnemyDoAttack("BasicAttack"));
            var = damage -= Player._player.Shield;
            Player._player.Health -= var;
            Player._player.Shield = 0;
            Player._player.UpdatePlayerUI();
            if (Player._player.Health <= 0)
            {
                GameManager._instance.LoseScreen.SetActive(true);
            }
        }
    }

    public void GoToPlayerState(){
        Debug.Log("Lets get out");
        StopAllCoroutines();
        myFSM.SetCurrentState(typeof(ApplyEnemyTicksOnPlayerState));
    }

    IEnumerator EnemyDoAttack(string whatDo)
    {
        EnemyBody._instanceEnemyBody.myAnimator.SetBool(whatDo, true);
        yield return new WaitForSeconds(0.1f);
        EnemyBody._instanceEnemyBody.myAnimator.SetBool(whatDo, false);
        StopCoroutine(ShowEnemyTurn());
    }

    IEnumerator ShowEnemyTurn()
    {
        UIManager._instanceUI.UIBanner.SetActive(true);
        UIManager._instanceUI.Title.text = "Enemy Turn";
        UIManager._instanceUI.undertitle.text =  "";
        UIManager._instanceUI.BannerAnimator.SetTrigger("ActivateBanner");
        yield return new WaitForSeconds(3f);
        EnemyAttackTurn();
    }

    IEnumerator GoToNextState(){
        yield return new WaitForSeconds(1.5f);
        GoToPlayerState();
    }

    private void Awake()
    {
        if (_enemyTurnInstance != null)
        {
            Destroy(gameObject);
        }
        _enemyTurnInstance = this;
    }
}