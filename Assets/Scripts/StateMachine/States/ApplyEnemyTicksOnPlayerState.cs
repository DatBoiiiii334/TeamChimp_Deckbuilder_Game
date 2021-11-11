using UnityEngine;

public class ApplyEnemyTicksOnPlayerState: State{

    public static ApplyEnemyTicksOnPlayerState _EnemyToPlayerTickInstance;
    public int forPlayerTicks, tickforPlayerDmg;
    //tickdmg has to come form enemy.cs but for now has to be like this

    public override void Enter()
    {
        print("ApplyEnemyTicksOnPlayerState");
        TickDamageToPlayer(tickforPlayerDmg);
    }

    public override void Exit()
    {
        Debug.Log("Exiting Apply Enemy Ticks On Player State");
    }

    public void TickDamageToPlayer(int tickDmg)
    {
        EnemyBody._instanceEnemyBody.Health -= tickDmg;
        if (forPlayerTicks > 0){forPlayerTicks -= 1;}
        myFSM.SetCurrentState(typeof(PlayerTurnState));
    }

    private void Awake()
    {
        if (_EnemyToPlayerTickInstance != null)
        {
            Destroy(gameObject);
        }
        _EnemyToPlayerTickInstance = this;
    }
}
