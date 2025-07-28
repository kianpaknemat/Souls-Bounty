using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;
    private string animBoolName;
    protected float stateTimer;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }
    public virtual void Enter()
    {
        if (!string.IsNullOrEmpty(animBoolName))
            player.Anim.SetBool(animBoolName, true);
    }
    public virtual void PhysicsUpdate() { }


    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }


    public virtual void Exit()
    {
        if (!string.IsNullOrEmpty(animBoolName))
            player.Anim.SetBool(animBoolName, false);
    }



}