using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPlayer : MonoBehaviour
{
    public GameObject player; 
    public float checkRadius = 5f; 
    public float checkAttack = 1.5f;
    public Animator animator;
    public float rotationSpeed = 100f;

    private void Start() {
        animator.SetBool("isWalking", false);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= checkRadius)
        {
            Debug.Log("Player is within range!");
            animator.SetBool("isWalking", true);
            animator.SetBool("Attack", false);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 2 * Time.deltaTime);
            lookAtPlayer();

            if (distanceToPlayer <= checkAttack)
            {
                Debug.Log("Player is within attack range!");
                animator.SetBool("isWalking", false);
                animator.SetBool("Attack", true);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("Attack", false);
        }
    }

    void lookAtPlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}