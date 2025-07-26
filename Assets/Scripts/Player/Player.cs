using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components
    public Animator Anim { get; private set; }
    #endregion

    #region States
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdelState IdleState { get; private set; } // Fixed spelling
    public PlayerMovementState MovementState { get; private set; }
    #endregion

    #region Movement
    public Rigidbody2D RB { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    public float MoveSpeed => moveSpeed;
    public float JumpForce => jumpForce;
    #endregion

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        Anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdelState(this, StateMachine, "Idel");
        MovementState = new PlayerMovementState(this, StateMachine, "Move");

        StateMachine.initialize(IdleState); 
    }

    private void Update()
    {
        StateMachine.currentState.Update();
    }
}
