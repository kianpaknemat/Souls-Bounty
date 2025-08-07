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

        bool wasOnWall = player.IsWall();

        if (wasOnWall)
        {
            float jumpDir = -player.transform.localScale.x;
            player.RB.linearVelocity = new Vector2(jumpDir * player.WallJumpHorizontalForce, player.JumpForce);

            player.transform.localScale = new Vector3(jumpDir, 1, 1);
        }
        else
        {
            player.RB.linearVelocity = new Vector2(player.RB.linearVelocity.x, player.JumpForce);
        }

        hasJumped = true;
        player.InputHandler.SetJumpUsed();
    }

    public override void Update()
    {
        base.Update();

        Vector2 input = player.InputHandler.MoveInput;

        float targetSpeedX = input.x * player.MoveSpeed;
        player.RB.linearVelocity = new Vector2(targetSpeedX, player.RB.linearVelocity.y);

        if (input.x < 0)
            player.transform.localScale = new Vector3(-1, 1, 1);
        else if (input.x > 0)
            player.transform.localScale = new Vector3(1, 1, 1);

        if (hasJumped && player.RB.linearVelocity.y < 0)
        {
            stateMachine.changeState(player.AirState);
        }
    }
}
