using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    private StateMachine _stateMachine;
    private Vector3 _currentPatrolPoint;
    private float _patrolPointReachedThreshold = 1.0f;

    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }

    public override void Enter() {
        Debug.Log("Entering Patrol State");
        _currentPatrolPoint = GetRandomPatrolPoint();
    }

    public override void Tick() {
        Debug.Log("Executing Patrol State logic");
        MoveTowardsPatrolPoint();
        if (Vector3.Distance(transform.position, _currentPatrolPoint) <= _patrolPointReachedThreshold) {
            Debug.Log("Reached patrol point");
            _stateMachine.ChangeState<AttackState>();
        }   
    }

    public override void Exit() {
        Debug.Log("Exiting Patrol State");
        _stateMachine.ChangeState<AttackState>();
    }

    private void MoveTowardsPatrolPoint() {
        transform.position = Vector3.MoveTowards(transform.position, _currentPatrolPoint, Time.deltaTime * 3.0f);
        waitPatrol();
    }
    private Vector3 GetRandomPatrolPoint() {
        float randomX = Random.Range(-10.0f, 10.0f);
        float randomZ = Random.Range(-10.0f, 10.0f);
        return new Vector3(randomX, transform.position.y, randomZ);
    }
    private IEnumerator waitPatrol() {
        yield return new WaitForSeconds(2);
        _stateMachine.ChangeState<AttackState>();
    }
}