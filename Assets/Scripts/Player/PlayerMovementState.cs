using UnityEngine;

public class PlayerMovementState : PlayerState
{
    public PlayerMovementState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (player.isBusy) return;

        Vector2 input = player.InputHandler.MoveInput;
        FlipCharacter(input.x);
        player.RB.linearVelocity = new Vector2(input.x * player.MoveSpeed, player.RB.linearVelocity.y);
    }




    private void FlipCharacter(float horizontalInput)
    {
        if (horizontalInput < 0)
            player.transform.localScale = new Vector3(-1, 1, 1);
        else if (horizontalInput > 0)
            player.transform.localScale = new Vector3(1, 1, 1);
    }
}
