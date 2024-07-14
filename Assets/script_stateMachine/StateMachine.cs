using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State CurrentState => _currentState;
    State _currentState;

    protected bool InTransition;

    private void Start() {
        ChangeState<DecideState>();
    }

    public void ChangeState<T>() where T : State {
        T targetState = GetComponent<T>();
        if (targetState == null) {
            print("tried to change to null state");
            return;
        }
        InititeNewState(targetState);
    }

    void InititeNewState(State targetState) {
        if (_currentState != targetState && !InTransition) {
            CallNewState(targetState);
        }
    }

    void CallNewState(State newState) {
        InTransition = true;
        _currentState?.Exit();
        _currentState = newState;
        _currentState?.Enter();

        InTransition = false;
    }

    private void Update() {
        if (CurrentState != null && !InTransition){
             CurrentState.Tick();
        }

    }

}
