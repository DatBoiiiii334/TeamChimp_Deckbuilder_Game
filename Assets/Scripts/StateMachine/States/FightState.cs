using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FightState: State{

    public override void Enter()
    {
        print("FightState");
        //Instantiate Game Level

        //Instantiate Player instance
        //Instantiate Enemy instantce
    }

    public override void Exit()
    {
        //Destroy Player instance
        //Destroy Enemy instance
    }

    public override void OnUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
           // myFSM.SetCurrentState(typeof(GridMapState));
        }
    }
}