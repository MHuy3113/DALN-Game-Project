using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DecideState : State
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
        WaitChangeState(2f);
        _stateMachine.ChangeState<PatrolState>();
    }
    public override void Exit() {
        print("In Decide");

    }
    
    IEnumerator WaitChangeState(float time) {
        yield return new WaitForSeconds(time);
    }

}
