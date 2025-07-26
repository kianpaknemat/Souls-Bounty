using UnityEngine;

public class Player : MonoBehaviour
{
    #region component
    public Animator anim {  get; private set; }


    #endregion


    #region state

    public PlayerStateMachine StateMachine {  get; private set; }
    public PlayerIdelState IdelState { get; private set; }
    public PlayerMovementState MovementState { get; private set; }

    #endregion

    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdelState = new PlayerIdelState(this,StateMachine,"Idel");
        MovementState = new PlayerMovementState(this,StateMachine,"Move");
    }


    private void Start()
    {
        anim = GetComponentInChildren<Animator>();

        StateMachine.initialize(IdelState);
    }

    private void Update()
    {
        StateMachine.currentState.Update();
    }
    

}
