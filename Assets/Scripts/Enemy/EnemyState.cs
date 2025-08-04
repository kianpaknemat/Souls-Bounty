using UnityEngine;

public class EnemyState
{
    protected EnemyStateMachin stateMachin;
    protected Enemy enemyBase;
    protected bool triggerCalled;
    protected string animBoolName;
    protected float startTimer;
    protected Rigidbody2D rb;
    



    public EnemyState(Enemy _enemyBase, EnemyStateMachin _enemyStateMachin, string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachin = _enemyStateMachin;
        this.animBoolName = _animBoolName;
        
    }
    public virtual void Enter()
    {
        triggerCalled = false;
        enemyBase.Anim.SetBool(animBoolName, true);
        rb = enemyBase.RB;

    }



    public virtual void Update()
    {
        startTimer -= Time.deltaTime;
    }


    public virtual void Exit() 
    {
        enemyBase.Anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;

    }
}
