using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.RB.linearVelocity = new Vector2(0, player.RB.linearVelocity.y);
    }

    public override void Update()
    {
        base.Update();
        
    }
}
