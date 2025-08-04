using UnityEngine;

public class SkeletonMove : SkeletonGroundedState
{
    public SkeletonMove(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton enemy)
        : base(_enemyBase, _enemyStateMachin, _animBoolName, enemy)
    {
    }

    bool isWaiting = false;
    float waitTimer = 0f;

    public override void Enter()
    {
        base.Enter();
        isWaiting = false;
        waitTimer = 0f;
    }

    public override void Update()
    {
        base.Update();

        int moveDir = (int)Mathf.Sign(enemy.transform.localScale.x);

        
        enemy.SetVelocity(enemy.moveSpeed * moveDir, enemy.RB.linearVelocity.y);


        if (enemy.IsWall() || !enemy.IsGrounded())
        {

            Vector3 scale = enemy.transform.localScale;
            scale.x *= -1;
            enemy.transform.localScale = scale;

            stateMachin.changeState(enemy.idleState);
        }
    }
}
