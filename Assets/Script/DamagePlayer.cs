using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class DamagePlayer: MonoBehaviour
    {
        public int damage = 25;

        private void OnTriggerEnter (Collider other)
        {
            StartCoroutine(DamagePlayer());
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
        }
    }
    IEnumerator DamagePlayer()
    {
        yield return new WaitForSeconds(2);
    }
}