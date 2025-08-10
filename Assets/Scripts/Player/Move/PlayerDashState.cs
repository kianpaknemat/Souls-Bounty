using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerDashState : PlayerState
{
    private Vector2 dashDir;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBoolName)
        : base(player, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();


        player.Anim.SetBool("Dash", true);
        SkillManagar.instance.CloneSkill.createClone(player.transform);
        float dir = player.dashDir;
        Vector2 input = player.InputHandler.MoveInput;
        dir = input.x;
        if (dir == 0)
        {
            float direction = player.transform.localScale.x;
            dir = direction;
        }

        dashDir = new Vector2(dir * player.dashSpeed, 0f);


        player.RB.gravityScale = 0;

        stateTimer = player.dashDuration;
    }

    public override void Update()
    {
        base.Update();

        stateTimer -= Time.deltaTime;

        if (player.IsWall())
        {
            player.RB.linearVelocity = Vector2.zero;

            if (player.IsGrounded())
                stateMachine.changeState(player.GroundedState);
            else
                stateMachine.changeState(player.wallSlide);

            return;
        }

        player.RB.linearVelocity = dashDir;

        if (stateTimer <= 0f)
        {
            if (player.IsGrounded())
                stateMachine.changeState(player.GroundedState);
            else
                stateMachine.changeState(player.AirState);
        }
    }



    public override void Exit()
    {
        base.Exit();


        player.Anim.SetBool("Dash", false);

        player.RB.gravityScale = 1;

        player.RB.linearVelocity = new Vector2(0, player.RB.linearVelocity.y);
    }
}
