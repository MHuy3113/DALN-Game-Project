using System.Collections;
using UnityEngine;

namespace SG
{
    public class DamagePlayer : MonoBehaviour
    {
        public int damage = 25;

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(DamagePlayerRoutine());
            PlayerStats playerStats = other.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
        }

        IEnumerator DamagePlayerRoutine()
        {
            yield return new WaitForSeconds(4);
        }
    }
}