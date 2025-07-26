using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementState : PlayerState
{
    public PlayerMovementState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
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

        if (Keyboard.current.aKey.isPressed)
        {
            Debug.Log("press a");

            stateMachine.changeState(player.IdelState);
            Debug.Log("press a2");

        }
    }
}
