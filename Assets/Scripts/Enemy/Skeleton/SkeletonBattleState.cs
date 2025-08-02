using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    EnemySkeleton enemy;
    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName, EnemySkeleton enemy) : base(_enemyBase, _enemyStateMachin, _animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

     public override void Update()
        {
            base.Update();
        }

    public override void Exit()
    {
        base.Exit();
    }

   

}
