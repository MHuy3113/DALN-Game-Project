using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageState : State
{
    public HpBoss boss;
    private StateMachine _stateMachine;

    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }

    public override void Enter() {
        Debug.Log("Entering Take Damage State");
    }

    public override void Tick() {
        Debug.Log("Executing Take Damage State logic");
        // if (boss.hp <= 0) {
        //     _stateMachine.ChangeState<DeathState>();
        // }   else if (boss > 60 && boss.hp < 80) {
        //     _stateMachine.ChangeState<AttackState>();
        // } 
        // else if (boss > 30 && boss.hp < 60) {
        //     _stateMachine.ChangeState<AttackState>();
        // } 
        // else {
        //     _stateMachine.ChangeState<IdleState>();
        // }
    }

    public override void Exit() {
        Debug.Log("Exiting Take Damage State");
    }
}