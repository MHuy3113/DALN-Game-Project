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
        // Thực hiện các hành động khi bắt đầu chết, ví dụ: phát hoạt animation chết, vô hiệu hóa đối tượng
    }

    public override void Tick() {
        Debug.Log("Executing Death State logic");
        // Boss đã chết, không cần thực hiện thêm hành động nào khác
    }

    public override void Exit() {
        Debug.Log("Exiting Death State");
    }
}
