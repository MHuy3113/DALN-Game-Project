using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageState : State
{
    private StateMachine _stateMachine;

    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }

    public override void Enter() {
        Debug.Log("Entering Take Damage State");
    }

    public override void Tick() {
        Debug.Log("Executing Take Damage State logic");

        _stateMachine.ChangeState<IdleState>();
    }

    public override void Exit() {
        Debug.Log("Exiting Take Damage State");
    }
}
