using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    private StateMachine _stateMachine;

    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }

    public override void Enter() {
        Debug.Log("Entering Idle State");
        Idle();
    }

    public override void Tick() { 
        Debug.Log("Executing Idle State logic");
        _stateMachine.ChangeState<DecideState>();
    }

    public override void Exit() {
        Debug.Log("Exiting Idle State");
    }
    private IEnumerator Idle() {
        yield return new WaitForSeconds(2);
        _stateMachine.ChangeState<AttackState>();
    }
}