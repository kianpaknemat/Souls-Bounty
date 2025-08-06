using UnityEngine;
public class SkeletonMove : SkeletonGroundedState
{
    public SkeletonMove(Enemy enemyBase, EnemyStateMachin enemyStateMachin, string animBoolName, EnemySkeleton enemy)
        : base(enemyBase, enemyStateMachin, animBoolName, enemy)
    {
    }

    private float minimumMoveTime = 1f; 
    private float moveTimer;

    public override void Enter()
    {
        base.Enter();
        moveTimer = minimumMoveTime; 
    }

    public override void Update()
    {
        base.Update();
        moveTimer -= Time.deltaTime;

        var hit = enemy.isPlayerDetected();
        if (hit.collider != null)
        {
            stateMachin.changeState(enemy.battleState);
            return;
        }

        int moveDir = (int)Mathf.Sign(enemy.transform.localScale.x);
        enemy.SetVelocity(enemy.moveSpeed * moveDir, enemy.RB.linearVelocity.y);

        if (moveTimer <= 0f && (enemy.IsWall() || !enemy.IsGrounded()))
        {
            Vector3 scale = enemy.transform.localScale;
            scale.x *= -1;
            enemy.transform.localScale = scale;
            stateMachin.changeState(enemy.idleState);
        }
    }
}