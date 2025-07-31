using UnityEngine;


public class EnemySkeleton : Enemy
{
    #region States
    public SkeletonIdle idleState { get; private set; }
    public SkeletonMove moveState { get; private set; }
    protected override void Awake()
    #endregion
    {
        base.Awake();
        idleState = new SkeletonIdle(this, stateMachin, "Idle", this);
        moveState = new SkeletonMove(this, stateMachin, "Move", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachin.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
}