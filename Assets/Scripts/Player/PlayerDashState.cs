using UnityEngine;

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

        // تعیین جهت دش
        float direction = player.transform.localScale.x;
        dashDir = new Vector2(direction * player.dashSpeed, 0f);

        // غیرفعال کردن گراویتی موقع دش (اختیاری ولی پیشنهاد میشه)
        player.RB.gravityScale = 0;

        stateTimer = player.dashDuration;
    }

    public override void Update()
    {
        base.Update();

        // اعمال سرعت ثابت در کل مدت دش
        player.RB.linearVelocity = dashDir;

        // کم کردن زمان
        stateTimer -= Time.deltaTime;

        if (stateTimer <= 0f)
        {
            // پایان دش → سوئیچ به استیت بعدی
            if (player.IsGrounded())
                stateMachine.changeState(player.GroundedState);
            else
                stateMachine.changeState(player.AirState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        // بازگردانی انیمیشن
        player.Anim.SetBool("Dash", false);

        // بازگردانی گراویتی
        player.RB.gravityScale = 1;

        // اختیاری: توقف کامل بعد دش
        player.RB.linearVelocity = new Vector2(0, player.RB.linearVelocity.y);
    }
}
