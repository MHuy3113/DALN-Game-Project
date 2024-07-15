using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideState : State
{
    protected StateMachine _stateMachine;
    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }

    public override void Enter() {
        Debug.Log("Start Decide");
    }

    public override void Exit() {
        Debug.Log("Exit Decide");
    }
    public override void Tick() {
    Debug.Log("Executing Decide logic");
    
    int id = Random.Range(0, 3);
    switch (id)
    {
        case 0:
            _stateMachine.ChangeState<PatrolState>();
            break;
        case 1:
            _stateMachine.ChangeState<AttackState>();
            break;
        case 2:
            _stateMachine.ChangeState<IdleState>();
            break;
    }
    }
}
