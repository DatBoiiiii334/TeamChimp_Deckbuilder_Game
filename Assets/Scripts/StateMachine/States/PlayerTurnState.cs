using System.Collections;
using UnityEngine;

public class PlayerTurnState : State
{
    public GameObject CardDeckBlocker;
    private int PlayerTurnAmount;

    public override void Enter()
    {
        if(Player._player.Health <= 0){
            StopAllCoroutines();
            myFSM.SetCurrentState(typeof(PlayerLoseState));
        }else{
            GameManager._instance.FightScene.SetActive(true);
            StartCoroutine(ShowPlayerTurn());
        }
    }

    public override void Exit()
    {
        CardDeckBlocker.SetActive(true);
        //StartCoroutine(OnExit());
    }

    public void NextTurn()
    {
        myFSM.SetCurrentState(typeof(ApplyPlayerTicksOnEnemyState));
    }

    public void GivePlayerTurn()
    {
        //GameManager._instance.GiveHand();
        Player._player.Mana = 5;
        Player._player.UpdatePlayerUI();
        CardDeckBlocker.SetActive(false);
        UIManager._instanceUI.UIBanner.SetActive(false);
        StopAllCoroutines();
        StartCoroutine(WaitForCards());
    }

    IEnumerator OnExit(){
        GameManager._instance.TransitionScreenAnim.SetTrigger("StartTransition");
        yield return new WaitForSeconds(1f);
        GameManager._instance.FightScene.SetActive(false);
    }

    IEnumerator ShowPlayerTurn()
    {
        PlayerTurnAmount += 1;
        UIManager._instanceUI.UIBanner.SetActive(true);
        UIManager._instanceUI.Title.text = "Player Turn";
        UIManager._instanceUI.undertitle.text = PlayerTurnAmount + "th turn";
        UIManager._instanceUI.BannerAnimator.SetTrigger("ActivateBanner");
        
        yield return new WaitForSeconds(2.4f);
        GivePlayerTurn();
    }

    IEnumerator WaitForCards(){
        //CardSystemManager._instance.StartCoroutine(CardSystemManager._instance.MoveCardsToPile());
        yield return new WaitForSeconds(2f);
        CardSystemManager._instance.StartCoroutine(CardSystemManager._instance.MoveCardsToDeck());
        StopCoroutine(WaitForCards());
    }
}
