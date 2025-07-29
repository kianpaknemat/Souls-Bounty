using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerInputActions inputActions;
    private Vector2 moveInput;
    private bool jumpPressed;
    private bool dashPressed;
    private bool jumpUsed;

    private bool attackPressed;

    public Vector2 MoveInput => moveInput;


    public bool JumpPressed => jumpPressed && !jumpUsed;

    public bool DashPressed => dashPressed;

    public bool AttackPressed => attackPressed;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        inputActions.Player.Move.performed += ctx => {
            moveInput = ctx.ReadValue<Vector2>();
        };

        inputActions.Player.Move.canceled += ctx => {
            moveInput = Vector2.zero;
        };



        inputActions.Player.Jump.performed += ctx => {
            jumpPressed = true;
            jumpUsed = false;  
        };
        inputActions.Player.Jump.canceled += ctx => {
            jumpPressed = false;
            jumpUsed = false;  
        };

        inputActions.Player.Dash.performed += ctx => dashPressed = true;
        inputActions.Player.Dash.canceled += ctx => dashPressed = false;


        inputActions.Player.Attack.performed += ctx => attackPressed = true;
        inputActions.Player.Attack.canceled += ctx => attackPressed = false;
    }

    private void OnEnable() => inputActions?.Enable();
    private void OnDisable() => inputActions?.Disable();

    private void OnDestroy()
    {
        inputActions?.Dispose();
    }

    public void SetJumpUsed()
    {
        jumpUsed = true;
    }
}
