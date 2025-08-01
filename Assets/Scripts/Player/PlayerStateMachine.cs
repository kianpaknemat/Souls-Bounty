
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState currentState { get; private set; }

    public void initialize(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void changeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}