using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SG
{
    public class PlayerStats : CharacterStats
    {
        PlayerManager playerManager;
        public HealthBar healthBar;
        public StaminaBar staminaBar;


        AnimatorHandler animatorHandler;

        public float staminaRegenerationAmount = 25;
        public float staminaRegenTimer = 0;

        private void Awake()
        {
            playerManager = GetComponent<PlayerManager>();
            healthBar = FindAnyObjectByType<HealthBar>();
            staminaBar = FindAnyObjectByType<StaminaBar>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();

        }
        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetCurrentHealth(currentHealth);

            maxStamina = SetMaxStaminaFromStaminaLevel();
            currentStamina = maxStamina;
            staminaBar.SetMaxStamina(maxStamina);
            staminaBar.SetCurrentStamina(currentStamina);
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }
        
        private float SetMaxStaminaFromStaminaLevel()
        {
            
            maxStamina = staminaLevel * 10;
            return maxStamina;
        }

        public void TakeDamage(int damage)
        {
            if (playerManager.isInVulnerable)
                return;
            if (isDead)
                return;

            currentHealth = currentHealth - damage;

            healthBar.SetCurrentHealth(currentHealth);

            animatorHandler.PlayTargetAnimation("Damage_01", true);

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead_01", true);
                isDead = true;
            }
        }   
    
        public void TakeStaminaDamage(int damage)
        {
            currentStamina = currentStamina - damage;
            staminaBar.SetCurrentStamina(currentStamina);
        }

        public void RegenerateStamina()
        {   
            if(playerManager.isInteracting)
            {
                staminaRegenTimer = 0;
            }
            else
            {   
                staminaRegenTimer += Time.deltaTime;

                if (currentStamina < maxStamina && staminaRegenTimer > 1f)
                {
                    currentStamina += staminaRegenerationAmount * Time.deltaTime;
                    staminaBar.SetCurrentStamina (Mathf. RoundToInt(currentStamina));
                }
            
            }
            
        }

        public void HealPlayer(int healAmount)
        {
            currentHealth = currentHealth + healAmount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            healthBar.SetCurrentHealth(currentHealth);
        }
    }  
}