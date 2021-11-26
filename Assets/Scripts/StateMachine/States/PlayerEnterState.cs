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
        yield return new WaitForSeconds(3f);

        myFSM.SetCurrentState(typeof(PlayerTurnState));
    }
}
