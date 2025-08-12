using JetBrains.Annotations;
using System.Collections;
using UnityEditor.Experimental;
using UnityEngine;

public class Player : Entity
{



    

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public SkillManagar skill { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMovementState MovementState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerGroundedState GroundedState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerPrimeriAttack FirstAttack { get; private set; }
    #endregion

    #region Movement
    [Header("movement")]

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    public float WallJumpHorizontalForce = 6f;

    [Header("dash")]
    [SerializeField] public float dashSpeed = 10f;
    [SerializeField] public float dashDuration = 10f;
    public float dashDir;

    public float MoveSpeed => moveSpeed;
    public float JumpForce => jumpForce;
    #endregion

    


    #region Attack
    public void AnimationTrigger() => StateMachine.currentState.AnimationFinishTrigger();
    public bool isBusy {  get; private set; }

    #endregion

    protected override void Awake()
    {
        base.Awake();
        
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, "Idel");
        MovementState = new PlayerMovementState(this, StateMachine, "Move");
        JumpState = new PlayerJumpState(this, StateMachine, "Jump");
        AirState = new PlayerAirState(this, StateMachine, "Jump");
        dashState = new PlayerDashState(this, StateMachine, "Dash");
        wallSlide = new PlayerWallSlideState(this, StateMachine, "WallSlide");


        FirstAttack = new PlayerPrimeriAttack(this, StateMachine, "Attack1");


        GroundedState = new PlayerGroundedState(this, StateMachine, "");

    }

    protected override void Start()
    {
        base.Start();
        InputHandler = GetComponent<PlayerInputHandler>();
        skill = SkillManagar.instance;
             
        StateMachine.initialize(GroundedState);
    }

  
    protected override void Update()
    {           
        base .Update();
        StateMachine.currentState.Update();
        bool Dash = InputHandler.DashPressed;
        Timer -= Time.deltaTime;
        if (Timer < 0 && Dash)
        {
            Timer = coolDown;
        }
       
    }

    public IEnumerator busyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);
        isBusy = false;
    }
    




}
