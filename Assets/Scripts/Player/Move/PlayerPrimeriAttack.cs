using UnityEngine;

public class PlayerPrimeriAttack : PlayerState

{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindo = 2;
    private float startTimer;
    public PlayerPrimeriAttack(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (comboCounter > 2 || Time.time >= lastTimeAttacked + comboWindo) { 
            comboCounter = 0;
        }
        stateTimer = .1f;
        
        player.Anim.SetInteger("comboCounter", comboCounter);

    }


    public override void Exit()
    {
        base.Exit();
        player.StartCoroutine("busyFor", .15f);
        comboCounter++;
        lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer < 0)
        {
            player.RB.linearVelocity = new Vector2(0, player.RB.linearVelocity.y);
        }


        if (triggerCalled)
        {
            stateMachine.changeState(player.GroundedState);
        }
    }

    

}
