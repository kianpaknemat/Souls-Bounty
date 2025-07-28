using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    private PlayerState subState;

    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        SetSubState(player.IdleState);
    }

    public override void Exit()
    {
        subState?.Exit();
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsGrounded())
        {
            stateMachine.changeState(player.AirState);
            return;
        }


        #region keyboard input
        Vector2 input = player.InputHandler.MoveInput;
        bool jump = player.InputHandler.JumpPressed;
        bool Dash = player.InputHandler.DashPressed;
        #endregion


        if (jump)
        {
            SetSubState(player.JumpState);
            return;
        }
        
        if (Dash && player.Timer < 0)
        {
            player.Timer = player.coolDown;
            stateMachine.changeState(player.dashState);
            return;
        }




        if (Mathf.Abs(input.x) > 0.1f)
        {
            SetSubState(player.MovementState);
        }
        else
        {
            SetSubState(player.IdleState);
        }

        subState?.Update();
    }

    private void SetSubState(PlayerState newSubState)
    {
        if (subState == newSubState)
            return;

        subState?.Exit();
        subState = newSubState;
        subState.Enter();
    }
}
