using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    private StateMachine _stateMachine;
    private void Awake() {
        _stateMachine = GetComponent<StateMachine>();
    }

    public override void Enter() {
        Debug.Log("Entering Death State");
        // Play death animation
        // Disable boss object
    }

    public override void Tick() {
        Debug.Log("Executing Death State logic");
        // Boss is dead, no further actions needed
    }

    public override void Exit() {
        Debug.Log("Exiting Death State");
    }
}