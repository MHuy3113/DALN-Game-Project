using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyStats : CharacterStats
    {
        public HealthBar healthbar;
        public GameObject enemy;
        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();

        }
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthbar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }
        
        public void TakeDamage(int damage)
        {
            if (isDead)
                return;
            currentHealth = currentHealth - damage;
            
            healthbar.SetCurrentHealth(currentHealth);

            animator.Play("Damage_01");

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Dead_01");
                isDead = true;
                PlayerDestroy();
            }
        }   
        public void PlayerDestroy()
        {
            StartCoroutine(DestroyPlayer());
            IEnumerator DestroyPlayer()
            {
                yield return new WaitForSeconds(4);
                gameObject.SetActive(false);
            }
        }
        
        private void OnValidate() {
            enemy = gameObject;
        }
    
    }  
}