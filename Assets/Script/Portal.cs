using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public float riseSpeed = 1f; 
    private bool shouldRise = false; 
    public GameObject dragon;


    void Update()
    {
        if (shouldRise)
        {
            transform.position += Vector3.up * riseSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldRise = true;
            dragon.SetActive(true);
        }
    }
}