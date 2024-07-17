using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackCharacter : MonoBehaviour
{

    void  OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player is within the sphere");
        }
    }

}