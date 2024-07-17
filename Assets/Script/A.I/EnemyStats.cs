using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class EnemyStats : CharacterStats
    {
        public HealthBar healthbar;

        Animator animator;
        EnemyAnimatorManager enemyAnimatorManager;

        public UIEnemyHealthBar enemyHealthBar;

        public int soulsAwardedOnDeath = 50;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            enemyAnimatorManager = GetComponentInChildren<EnemyAnimatorManager>();

        }
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            enemyHealthBar.SetMaxHealth(maxHealth);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }
        

        public void TakeDamageNoAnimation(int damage)
        {
            currentHealth = currentHealth - damage;

            enemyHealthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDead = true;
            }
        }   

        public void TakeDamage(int damage)
        {
            if (isDead)
                return;
                
            currentHealth = currentHealth - damage;
            enemyHealthBar.SetHealth(currentHealth);
            
            healthbar.SetCurrentHealth(currentHealth);

            enemyAnimatorManager.PlayTargetAnimation("Damage_01", true);

            if (currentHealth <= 0)
            {
                HandleDeath();
            }
        } 

        private void HandleDeath()
        {
            currentHealth = 0;
            enemyAnimatorManager.PlayTargetAnimation("Dead_01",true);
            isDead = true;

        }  
    
    }  
}