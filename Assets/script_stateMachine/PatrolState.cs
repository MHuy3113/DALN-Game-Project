using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    private StateMachine _stateMachine;
    private Vector3 _patrolPoint;
    private float _patrolSpeed = 2f;

    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }

    public override void Enter() {
        Debug.Log("Entering Patrol State");
        _patrolPoint = GetRandomPatrolPoint();
    }

    public override void Tick() {
        Debug.Log("Executing Patrol State logic");
        Patrol();

        if (DetectPlayer()) {
            _stateMachine.ChangeState<AttackState>();
        }
    }

    public override void Exit() {
        Debug.Log("Exiting Patrol State");
    }

    private Vector3 GetRandomPatrolPoint() {
        return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }

    private void Patrol() {
        transform.position = Vector3.MoveTowards(transform.position, _patrolPoint, _patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _patrolPoint) > 0.5f) {
            DetectPlayer();
        }
    }

    private bool DetectPlayer() {
        float detectionRange = 5f;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (var hitCollider in hitColliders) {
            if (hitCollider.CompareTag("Player")) {
                return true;
            }
        }
        return false;
    }
    IEnumerator WaitChangeState(float waitTime) {
        yield return new WaitForSeconds(waitTime);
    }
}
