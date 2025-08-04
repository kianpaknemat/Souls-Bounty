using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    private EnemySkeleton enemy;
    private Transform player;
    private int moveDir;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton enemy) : base(_enemyBase, _enemyStateMachin, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

     public override void Update()
        {
            base.Update();

        if (enemy.isPlayerDetected())
        {
            if (enemy.isPlayerDetected().distance < enemy.AttackDistance)
            {
                Debug.Log("i attacked");
                enemy.ZeroVelocity();
                return;
            }
        }



        if (player.position.x > enemy.transform.position.x)
            {
                moveDir = 1;
            }
        else if(player.position.x < enemy.transform.position.x)
        {
            moveDir = -1;
        }
        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.linearVelocity.y);
        }




    public override void Exit()
    {
        base.Exit();
    }

   

}
