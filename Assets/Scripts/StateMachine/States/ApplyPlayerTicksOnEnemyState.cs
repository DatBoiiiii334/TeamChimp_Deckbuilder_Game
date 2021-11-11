using UnityEngine;

public class ApplyPlayerTicksOnEnemyState : State
{
    public static ApplyPlayerTicksOnEnemyState _PlayerToEnemyTickInstance;
    public int forEnemyTicks;

    public override void Enter()
    {
        print("ApplyPlayerTicksOnEnemyState");
        if(forEnemyTicks > 0){
            TickDamageToEnemy(GameManager._instance.forEnemyTickDamage);
        }else{
            myFSM.SetCurrentState(typeof(EnemyTurnState));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Apply Player Ticks On Enemy State");
    }

    public void TickDamageToEnemy(int tickDmg)
    {
        EnemyBody._instanceEnemyBody.Health -= tickDmg;
        if (forEnemyTicks > 0){forEnemyTicks -= 1;}
        myFSM.SetCurrentState(typeof(EnemyTurnState));
    }

    private void Awake()
    {
        if (_PlayerToEnemyTickInstance != null)
        {
            Destroy(gameObject);
        }
        _PlayerToEnemyTickInstance = this;
    }
}