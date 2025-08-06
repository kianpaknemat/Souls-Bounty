using Unity.VisualScripting;
using UnityEngine;

public class skeletonStunned : EnemyState

{

    private EnemySkeleton enemy;
    public skeletonStunned(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton enemy) : base(_enemyBase, _enemyStateMachin, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        startTimer = enemy.stunDuretion;
        enemy.SetVelocity(-enemy.dir * enemy.standirection.x, enemy.standirection.y);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Exit()
    {
        base.Exit();
        if(startTimer < 0)
        {
            stateMachin.changeState(enemy.idleState);
        }
    }

}
