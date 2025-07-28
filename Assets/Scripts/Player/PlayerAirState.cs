using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {
    }



    public override void Update()
    {
        base.Update();

        Vector2 input = player.InputHandler.MoveInput;
        FlipCharacter(input.x);
        player.RB.linearVelocity = new Vector2(input.x * player.MoveSpeed, player.RB.linearVelocity.y);

        if (player.IsGrounded())
        {
            stateMachine.changeState(player.GroundedState);
        }
    }

    private void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput < 0)
            player.transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontalInput > 0)
            player.transform.localScale = new Vector3(1, 1, 1);
    }
}
