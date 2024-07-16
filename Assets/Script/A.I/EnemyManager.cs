using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SG
{
    public class EnemyManager : CharacterManager
    {
        EnemyLocomotionManager enemyLocomotionManager;
        EnemyAnimatorManager enemyAnimatorManager;
        EnemyStats enemyStats;
        public Rigidbody enemyRigidBody;
        public NavMeshAgent navMeshAgent;

        public State currentState;
        public CharacterStats currentTarget;

        public bool isInteracting;
        public bool isPreformingAction;
        public float rotationSpeed = 15;
        public float maximumAttackRange = 1.5f;

        public EnemyAttackAction[] enemyAttacks;
        public EnemyAttackAction currentAttack;

        [Header("AI Settings")]
        public float detectionRadius = 20;
        //the higher, the greater detection field of view
        public float maximumDetectionAngle = 50;
        public float minimumDetectionAngle = -50;

        public float currentRecoveryTime = 0;

        private void Awake()
        {
            enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();
            enemyStats = GetComponent<EnemyStats>();
            enemyRigidBody = GetComponent<Rigidbody>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            navMeshAgent.enabled = false;
        }

        private void Start()
        {
            enemyRigidBody.isKinematic = false;
        }
        

        private void Update()
        {
            HandleRecoveryTimer();

            isInteracting = enemyAnimatorManager.anim.GetBool("isInteracting");
        }
        private void FixedUpdate()
        {
            HandleStateMachine();
        }
        private void HandleStateMachine()
        {   
            if (enemyStats.isDead)
                return;  

            else if (currentState != null)
            {
                State nextState = currentState.Tick(this, enemyStats, enemyAnimatorManager);

                if (nextState != null)
                {
                    SwitchToNextState(nextState);
                }
            }
        }

        private void SwitchToNextState(State state)
        {
            currentState = state;
        }

        private void HandleRecoveryTimer()
        {
            if (currentRecoveryTime > 0)
            {
                currentRecoveryTime -= Time.deltaTime;
            }

            if (isPreformingAction)
            {
                if (currentRecoveryTime <= 0)
                {
                    isPreformingAction = false;
                }
            }
        }

    }
}