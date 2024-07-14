using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected StateMachine _stateMachine;
    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }
    public override void Enter() {
        print("Start Decide");
    }
    public override void Tick() {
        print("Exit Decide");
        _stateMachine.ChangeState<IdleState>();
    }
    public override void Exit() {
        print("In Decide");
    }

    
}
