using UnityEngine;

[CreateAssetMenu(fileName = "TickEffect", menuName = "Effects/TickDmg")]
public class TickEffect : BaseEffect
{
    public override void ApplyEffect()
    {
        ApplyPlayerTicksOnEnemyState._PlayerToEnemyTickInstance.forEnemyTicks += 3;
        ApplyPlayerTicksOnEnemyState._PlayerToEnemyTickInstance.TickDamageToEnemy(template.card.AttackDamage);
    }
}
