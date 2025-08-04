using UnityEngine;


public class SkeletonGroundedState : EnemyState
{
    protected EnemySkeleton enemy;
    protected Transform player;
    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton enemy) : base(_enemyBase, _enemyStateMachin, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.isPlayerDetected() || Vector2.Distance(enemy.transform.position,player.position) < 3)
        {
            stateMachin.changeState(enemy.battleState);
        }
    }
}
