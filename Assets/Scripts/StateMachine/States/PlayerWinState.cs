using UnityEngine;

public class PlayerWinState: State{

    public override void Enter()
    {
        print("PlayerWinState");
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
            //myFSM.SetCurrentState(typeof(GridMapState));
        }
    }
}
