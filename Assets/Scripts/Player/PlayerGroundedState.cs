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

        Vector2 input = player.InputHandler.MoveInput;
        bool jump = player.InputHandler.JumpPressed;
        bool dash = player.InputHandler.DashPressed;
        bool attack = player.InputHandler.AttackPressed;

        if (attack)
        {
            stateMachine.changeState(player.FirstAttack);
            return; 
        }

        if (jump)
        {
            SetSubState(player.JumpState);
            return;
        }

        if (dash && player.Timer < 0)
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
