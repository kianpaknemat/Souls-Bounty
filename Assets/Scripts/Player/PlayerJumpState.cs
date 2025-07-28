using UnityEngine;

public class PlayerJumpState : PlayerState
{
    private bool hasJumped;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        hasJumped = false;

        player.RB.linearVelocity = new Vector2(player.RB.linearVelocity.x, player.JumpForce);
        hasJumped = true;
    }

    public override void Update()
    {
        base.Update();

        if (hasJumped && player.RB.linearVelocity.y < 0)
        {
            stateMachine.changeState(player.AirState);
        }
    }
}
