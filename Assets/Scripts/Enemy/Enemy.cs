using UnityEngine;

public class Enemy : Entity
{
    protected float direction;
    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Move")]
    public float moveSpeed;
    public float IdleTime;
    
    


    [Header("Attack Info")]
    public float AttackDistance;
    public float attackCollDown;
    [HideInInspector] public float lastAttackTime;
    public float battleTime;

    public EnemyStateMachin stateMachin;

    protected override void Awake()
    {
        base.Awake();
        stateMachin = new EnemyStateMachin();
    }

    protected override void Update()
    {
        base.Update();
        stateMachin.currentState.Update();
        direction = Mathf.Sign(transform.localScale.x);

        RaycastHit2D hit = isPlayerDetected();
    }
    public void SetVelocity(float x, float y)
    {
        if (RB != null)
            RB.linearVelocity = new Vector2(x, y);    

        if (x > 0)
            transform.localScale = new Vector3(1, 1, 1);  
        else if (x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    public void SetZeroVelocity()
    {
        if (RB != null)
            RB.linearVelocity = Vector2.zero;
    }




    protected virtual void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + AttackDistance * direction, transform.position.y));
    }



    public virtual RaycastHit2D isPlayerDetected() =>
        Physics2D.Raycast(wallCheck.position, Vector2.right * direction, 50, whatIsPlayer);


    public virtual void AnimationFinishTrigger() => stateMachin.currentState.AnimationFinishTrigger();
}
