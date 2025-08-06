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
        startTimer = enemy.battleTime;
    }

    public override void Update()
    {
        base.Update();
        startTimer -= Time.deltaTime;

        var hit = enemy.isPlayerDetected();

        if (hit.collider != null)
        {
            if (hit.distance < enemy.AttackDistance)
            {
                if (canAttack())
                {
                    stateMachin.changeState(enemy.AttackState);
                    return;
                }
            }
            else if (startTimer < 0 || Vector2.Distance(player.position, enemy.transform.position) > 10)
            {
                stateMachin.changeState(enemy.idleState);
                return;
            }
        }
        else
        {
            if (startTimer < 0 || Vector2.Distance(player.position, enemy.transform.position) > 10)
            {
                stateMachin.changeState(enemy.idleState);
                return;
            }
        }

        float playerDistance = Vector2.Distance(enemy.transform.position, player.position);

        if (playerDistance > enemy.AttackDistance && playerDistance < 10)
        {
            int moveDir = player.position.x > enemy.transform.position.x ? 1 : -1;
            enemy.SetVelocity(enemy.moveSpeed * moveDir, enemy.RB.linearVelocity.y);
        }
        else
        {
            enemy.SetZeroVelocity();
        }
     }


    public override void Exit()
    {
        base.Exit();
    }

    private bool canAttack()
    {
        if (Time.time >= enemy.lastAttackTime + enemy.attackCollDown)
        {
            enemy.lastAttackTime = Time.time;
            return true;
        }
        else { return false; }
    }
   

}
