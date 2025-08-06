using UnityEngine;
public class SkeletonIdle : SkeletonGroundedState
{
    public SkeletonIdle(Enemy enemyBase, EnemyStateMachin enemyStateMachin, string animBoolName, EnemySkeleton enemy) : base(enemyBase, enemyStateMachin, animBoolName, enemy)
    {
    }
    float waitTime;
    public override void Enter()
    {
        base.Enter();
        waitTime = enemy.IdleTime;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();

        var hit = enemy.isPlayerDetected();

        if (hit.collider != null)
        {
            stateMachin.changeState(enemy.battleState);
            return;
        }

        waitTime -= Time.deltaTime;
        if (waitTime <= 0f)
        {
            stateMachin.changeState(enemy.moveState);
        }
    }
}