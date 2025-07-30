using UnityEngine;

public class EnemyStateMachin
{
    public EnemyState currentState { get ; private set; }
    public void Initialize(EnemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void changeState(EnemyState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}

