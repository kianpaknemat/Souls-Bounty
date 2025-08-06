using UnityEngine;

public class SkeletonIdle : SkeletonGroundedState
{
    public SkeletonIdle(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton enemy) : base(_enemyBase, _enemyStateMachin, _animBoolName, enemy)
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

        float playerDistance = Vector2.Distance(enemy.transform.position, player.position);
        float detectionRange = 1f; 

        if (playerDistance > detectionRange)
        {
            waitTime -= Time.deltaTime;
            if (waitTime < 0f)
            {
                stateMachin.changeState(enemy.moveState);
            }
        }
        else
        {
            waitTime = enemy.IdleTime;
        }
    }


}
