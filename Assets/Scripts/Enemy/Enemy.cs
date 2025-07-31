using UnityEngine;

public class Enemy : Entity

{
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
    }


}
