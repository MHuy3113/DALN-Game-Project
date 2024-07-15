using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    protected StateMachine _stateMachine;
    private Transform _target;
    private float _attackRange = 3.0f;

    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }

    public override void Enter() {
        print("Start Attack");
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null) {
            _target = playerObject.transform;
        }
    }

    public override void Tick() {
        if (_target == null) {
            _stateMachine.ChangeState<IdleState>();
            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, _target.position);

        if (distanceToTarget <= _attackRange) {
            Debug.Log("Attacking the target");
            Attack();
            _stateMachine.ChangeState<IdleState>();
        } else {
            MoveTowardsTarget();
        }
    }

    public override void Exit() {
        print("Exit Attack");
    }

    private void Attack() {
        print("Attacking the target");
        _stateMachine.ChangeState<DecideState>();
        // _target.GetComponent<PlayerHealth>().TakeDamage(10);
    }

    private void MoveTowardsTarget() {
        print("Moving towards the target");
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * 3.0f);
    }
}