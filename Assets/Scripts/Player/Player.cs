using JetBrains.Annotations;
using System.Collections;
using UnityEditor.Experimental;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator Anim { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMovementState MovementState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerGroundedState GroundedState { get; private set; }
    public PlayerWallSlideState wallSlide { get; private set; }


    public PlayerPrimeriAttack FirstAttack { get; private set; }
    #endregion

    #region Movement
    [Header("movement")]
    public Rigidbody2D RB { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public PlayerDashState dashState { get; private set; }

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

    #region check
    [Header("check wall & ground")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    public Transform wallCheck;
    public float wallCheckRadius = 0.2f;
    public LayerMask walldLayer;
    public bool IsWall()
    {
        Vector2 direction = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        return Physics2D.Raycast(wallCheck.position, direction, wallCheckRadius, walldLayer);
    }
    #endregion

    #region time
    [Header("Time")]
    public float Timer;
    public float coolDown = 5f;

    #endregion

    #region Attack
    public void AnimationTrigger() => StateMachine.currentState.AnimationFinishTrigger();
    public bool isBusy {  get; private set; }

    #endregion

    private void Awake()
    {
        
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

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Anim = GetComponentInChildren<Animator>();     
        StateMachine.initialize(GroundedState);
    }

  
    private void Update()
    {           
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
