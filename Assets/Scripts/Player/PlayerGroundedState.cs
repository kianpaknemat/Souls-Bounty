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

        // اگر از زمین جدا شدی، برو AirState
        if (!player.IsGrounded())
        {
            stateMachine.changeState(player.AirState);
            return;
        }

        // ورودی‌ها رو بخون
        Vector2 input = player.InputHandler.MoveInput;
        bool jump = player.InputHandler.JumpPressed;

        // اگر دکمه پرش زده شده، برو JumpState
        if (jump)
        {
            SetSubState(player.JumpState);
            return;
        }

        // اگر ورودی حرکت داری، برو MovementState
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
