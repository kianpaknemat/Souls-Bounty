using UnityEngine;

public class EnemyStat : CharecterStats
{
    private Enemy enemy;

    public EnemyStat(Enemy enemy, PlayerStateMachine stateMachine, string animBoolName)
    {
    }

    protected override void Start()
    {
        base.Start();
        enemy = GetComponent<Enemy>();
    }
    public override void takeDamage(int _damage)
    {
        base.takeDamage(_damage);
        enemy.DamageEffect();
    }
    protected override void Die()
    {
        base.Die();
    }

}
