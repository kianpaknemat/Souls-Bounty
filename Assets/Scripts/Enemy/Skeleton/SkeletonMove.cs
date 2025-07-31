using UnityEngine;

public class SkeletonMove : EnemyState
{
    EnemySkeleton enemy;

    bool isWaiting = false;
    float waitTimer = 0f;

    public SkeletonMove(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton _enemy) :
        base(_enemyBase, _enemyStateMachin, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        isWaiting = false;
        waitTimer = 0f;
    }

    public override void Update()
    {
        base.Update();

        float direction = Mathf.Sign(enemy.transform.localScale.x);
        Vector3 moveDir = new Vector3(direction, 0f, 0f);
        enemy.transform.position += moveDir * enemy.moveSpeed * Time.deltaTime;

        if (enemy.IsWall() || !enemy.IsGrounded())
        {
       
            Vector3 scale = enemy.transform.localScale;
            scale.x *= -1;
            enemy.transform.localScale = scale;
            stateMachin.changeState(enemy.idleState);
        }
    }

}
