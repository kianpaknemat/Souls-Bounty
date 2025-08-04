using UnityEngine;

public class SkeletonAttackState : EnemyState
{
    private EnemySkeleton enemy;
    public SkeletonAttackState(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton enemy) : base(_enemyBase, _enemyStateMachin, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        enemy.SetZeroVelocity ();
        if (triggerCalled)
        {
            stateMachin.changeState(enemy.battleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        enemy.lastAttackTime = Time.time;
    }

}
