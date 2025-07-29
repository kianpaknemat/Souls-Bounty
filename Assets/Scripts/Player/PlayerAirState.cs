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


        #region keyboard input
        Vector2 input = player.InputHandler.MoveInput;
        FlipCharacter(input.x);
        player.RB.linearVelocity = new Vector2(input.x * player.MoveSpeed, player.RB.linearVelocity.y);
        bool Dash = player.InputHandler.DashPressed;
#endregion

        if (player.IsGrounded())
        {
            stateMachine.changeState(player.GroundedState);
        }


        if (Dash && player.Timer < 0)
        {
            player.Timer = player.coolDown;
            stateMachine.changeState(player.dashState);
            return;
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
