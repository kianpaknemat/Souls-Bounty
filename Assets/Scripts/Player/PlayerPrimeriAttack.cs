using UnityEngine;

public class PlayerPrimeriAttack : PlayerState

{
    public PlayerPrimeriAttack(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.RB.linearVelocity = Vector2.zero;
    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.RB.linearVelocity = new Vector2(0, player.RB.linearVelocity.y);

        if (triggerCalled)
        {
            stateMachine.changeState(player.GroundedState);
        }
    }

}
