// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class enemyState_boss : MonoBehaviour
// {
//         public int healthLevel = 10;
//         public int maxHealth;
//         public int currentHealth;
//         public HealthBar healthbar;

//         Animator animator;

//         void Start()
//         {
//             maxHealth = SetMaxHealthFromHealthLevel();
//             currentHealth = maxHealth;
//             healthbar.SetMaxHealth(maxHealth);
//         }

//         private int SetMaxHealthFromHealthLevel()
//         {
//             maxHealth = healthLevel * 10;
//             return maxHealth;
//         }
        
//         public void TakeDamage(int damage)
//         {
//             currentHealth = currentHealth - damage;
            
//             healthbar.SetCurrentHealth(currentHealth);

//             if (currentHealth <= 0)
//             {
//                 currentHealth = 0;
//                 //Handle Player Death
//             }
//         } 
// }
