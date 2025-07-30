using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachin stateMachin;
    protected Enemy enemy;
    protected bool triggerCalled;
    protected string animBoolName;
    protected float startTimer;
    



    public EnemyState(Enemy _enemy, EnemyStateMachin _enemyStateMachin, string _animBoolName)
    {
        this.enemy = _enemy;
        this.stateMachin = _enemyStateMachin;
        this.animBoolName = _animBoolName;
        
    }
    public virtual void Enter()
    {
        triggerCalled = false;

    }


    public virtual void Update()
    {
        startTimer -= Time.deltaTime;
    }


    public virtual void Exit() 
    {
    }
}
