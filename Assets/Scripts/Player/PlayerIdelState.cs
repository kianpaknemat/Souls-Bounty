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

        Vector2 input = player.InputHandler.MoveInput;

        if (input.x != 0)
        {
            stateMachine.changeState(player.MovementState);
        }
    }


}
