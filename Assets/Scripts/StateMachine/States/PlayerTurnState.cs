using System.Collections;
using UnityEngine;

public class PlayerTurnState : State
{
    public GameObject CardDeckBlocker;
    private int PlayerTurnAmount;

    public override void Enter()
    {
        StartCoroutine(ShowPlayerTurn());
    }

    public override void Exit()
    {
        CardDeckBlocker.SetActive(true);
    }

    public void NextTurn()
    {
        myFSM.SetCurrentState(typeof(ApplyPlayerTicksOnEnemyState));
    }

    public void GivePlayerTurn()
    {
        GameManager._instance.GiveHand();
        Player._player.Mana = 5;
        Player._player.UpdatePlayerUI();
        CardDeckBlocker.SetActive(false);
        UIManager._instanceUI.UIBanner.SetActive(false);
        StopAllCoroutines();
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
}
