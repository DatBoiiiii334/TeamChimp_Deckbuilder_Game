using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnterState : State
{
    public override void Enter()
    {
        print("Player enter state");
        StartCoroutine(WaitToEnter());
    }

    private IEnumerator WaitToEnter()
    {
        GameManager._instance.FightScene.SetActive(true);

        // for(int i = 0; i < 2; i++){
        CardController.instance_CardController.BuyCard();
        // }
        yield return new WaitForSeconds(3f);
        CardSystemManager._instance._MoveCardsToPile();
        yield return new WaitForSeconds(2f);
        myFSM.SetCurrentState(typeof(PlayerTurnState));
    }
}
