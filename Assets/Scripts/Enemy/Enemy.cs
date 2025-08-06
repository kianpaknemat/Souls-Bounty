using UnityEngine;

public class Enemy : Entity
{
    protected float direction;
    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Move")]
    public float moveSpeed;
    public float IdleTime;

    [Header("stunned info")]
    public float stunDuretion;
    public Vector2 standirection;


    [Header("Attack Info")]
    public float AttackDistance;
    public float attackCollDown;
    [HideInInspector] public float lastAttackTime;
    public float battleTime;

    public EnemyStateMachin stateMachin;
    public float dir;

    protected override void Awake()
    {
        base.Awake();
        stateMachin = new EnemyStateMachin();
    }

    protected override void Update()
    {
        base.Update();
        stateMachin.currentState.Update();
        dir = GetDirection();

        RaycastHit2D hit = isPlayerDetected();
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
