using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerIdelState : PlayerState
{
    public PlayerIdelState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Keyboard.current.dKey.isPressed)
        {
            stateMachine.changeState(player.MovementState);
        }
    }
}
