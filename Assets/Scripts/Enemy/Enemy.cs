using UnityEngine;

public class Enemy : Entity
{
    protected float direction;
    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Move")]
    public float moveSpeed;
    public float IdleTime;

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

    public virtual RaycastHit2D isPlayerDetected() =>
        Physics2D.Raycast(wallCheck.position, Vector2.right * direction, 50, whatIsPlayer);
}
