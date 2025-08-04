using UnityEngine;


public class SkeletonGroundedState : EnemyState
{
    protected EnemySkeleton enemy;
    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton enemy) : base(_enemyBase, _enemyStateMachin, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.isPlayerDetected())
        {
            stateMachin.changeState(enemy.battleState);
        }
    }
}
