using UnityEngine;

public class SkeletonIdle : EnemyState
{
    EnemySkeleton enemy;
    float waitTime;
    public SkeletonIdle(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton _enemy
        ) : base(_enemyBase, _enemyStateMachin, _animBoolName)
    {
        enemy = _enemy;
    }

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
        waitTime -= Time.deltaTime;
        if (waitTime < 0f)
        {
            stateMachin.changeState(enemy.moveState);
        }
    }
}
