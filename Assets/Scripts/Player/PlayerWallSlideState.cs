using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.RB.gravityScale = 0.5f; 
        player.RB.linearVelocity = new Vector2(0, -1f); 
    }

    public override void Update()
    {
        base.Update();

        bool dash = player.InputHandler.DashPressed;
        bool jump = player.InputHandler.JumpPressed;

        if (jump)
        {
            stateMachine.changeState(player.JumpState);
            return;
        }

        if (dash && player.Timer < 0)
        {
            player.Timer = player.coolDown;
            stateMachine.changeState(player.dashState);
            return;
        }

        if (player.IsGrounded())
        {
            stateMachine.changeState(player.GroundedState);
            return;
        }

        Vector2 input = player.InputHandler.MoveInput;

        if (input != Vector2.zero && Mathf.Sign(input.x) != Mathf.Sign(player.transform.localScale.x))
        {
            if (player.IsGrounded())
                stateMachine.changeState(player.GroundedState);
            else
                stateMachine.changeState(player.AirState);

            return;
        }

        if (!player.IsWall())
        {
            stateMachine.changeState(player.AirState);
            return;
        }

        player.RB.linearVelocity = new Vector2(0, -2f);
    }




    public override void Exit()
    {
        base.Exit();
        player.RB.gravityScale = 1f;
    }
}
