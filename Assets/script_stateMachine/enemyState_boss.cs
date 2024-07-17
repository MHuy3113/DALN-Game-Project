// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using SG; // Add this line to use the SG namespace where PlayerStats is defined
// [[RequireComponent(typeof(MeshCollider))]]
// public class enemyState_boss : MonoBehaviour
// {
//     public int damage = 25;
//     public PlayerStats playerStats;
//     private void OnTriggerEnter(Collider other)
//     {
//         PlayerStats playerStats = other.GetComponent<PlayerStats>();
//         if (playerStats != null)
//         {
//             playerStats.TakeDamage(damage);
//             Debug.Log("Player has taken damage!");
//         }
//     }
// }