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
    }

    public override void Tick() { 
        Debug.Log("Executing Idle State logic");
        StartCoroutine(WaitChangeState(2f));
        _stateMachine.ChangeState<PatrolState>();
    }

    public override void Exit() {
        Debug.Log("Exiting Idle State");
    }
    IEnumerator WaitChangeState(float waitTime) {
        yield return new WaitForSeconds(waitTime);
    }
}
