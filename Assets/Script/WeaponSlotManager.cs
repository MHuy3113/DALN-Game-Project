using System.Collections;
using System.Collections.Generic;
using SG;
using UnityEditor.Experimental.Licensing;
using UnityEngine;

namespace SG
{
    public class WeaponSlotManager : MonoBehaviour
    {
        PlayerManager playerManager;
        public WeaponItem attackingWeapon;

        WeaponHolderSlot leftHandSlot;
        WeaponHolderSlot rightHandSlot;
        WeaponHolderSlot backSlot;

        DamageCollider leftHandDamageCollider;
        DamageCollider rightHandDamageCollider;


        Animator animator;
        QuickSlotsUI quickSlotsUI;
        PlayerStats playerStats;
        InputHandler inputHandler;

        private void Awake()
        {
            playerManager= GetComponentInParent<PlayerManager>();
            animator = GetComponent<Animator>();
            quickSlotsUI = FindObjectOfType<QuickSlotsUI>();
            playerStats = GetComponentInParent<PlayerStats>();
            inputHandler = GetComponentInParent<InputHandler>();

            WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
            foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
            {
                if(weaponSlot.isLeftHandSlot)
                {
                    leftHandSlot = weaponSlot;
                }
                else if(weaponSlot.isRightHandSlot)
                {
                    rightHandSlot = weaponSlot;
                }
                else if(weaponSlot.isBackSlot)
                {
                    backSlot = weaponSlot;
                }
            }   
        }

        public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft)
        {
            if(isLeft)
            {
                leftHandSlot.currentWeapon = weaponItem;
                leftHandSlot.LoadWeaponModel(weaponItem);
                LoadLeftWeaponDamageCollider();
                quickSlotsUI.UpdateWeaponQuickSlotsUI(true, weaponItem);

                #region Handle Left Weapon Idle Animation
                if(weaponItem != null)
                {
                    animator.CrossFade(weaponItem.left_hand_idle, 0.2f);
                }
                else
                {
                    animator.CrossFade("Left Arm Empty", 0.2f);
                }
                #endregion
                
            }
            else
            {
                
                if(inputHandler.twoHandFlag)
                {
                    backSlot.LoadWeaponModel(leftHandSlot.currentWeapon);
                    leftHandSlot.UnloadWeaponAndDestroy();
                    animator.CrossFade(weaponItem.th_idle, 0.2f);
                }
                else
                {

                    #region Handle Right Weapon Idle Animation

                    animator.CrossFade("Both Arms Empty", 0.2f);

                    backSlot.UnloadWeaponAndDestroy();
                    if(weaponItem != null)
                    {
                        
                        animator.CrossFade(weaponItem.right_hand_idle, 0.2f);
                    }
                    else
                    {
                        animator.CrossFade("Right Arm Empty", 0.2f);
                    }
                    #endregion
                }

                rightHandSlot.currentWeapon = weaponItem;
                rightHandSlot.LoadWeaponModel(weaponItem);
                LoadRightWeaponDamageCollider();
                quickSlotsUI.UpdateWeaponQuickSlotsUI(false, weaponItem);
            }
        }
          

        #region Handle Weapon Damage Collider

        private void LoadLeftWeaponDamageCollider()
        {
            leftHandDamageCollider = leftHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }
        private void LoadRightWeaponDamageCollider()
        {
            rightHandDamageCollider = rightHandSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }

        public void OpenDamageCollider()
        {
            if(playerManager.isUsingRightHand)
            {
                rightHandDamageCollider.EnableDamageCollider();
            }
            else if (playerManager.isUsingLeftHand)
            {
                leftHandDamageCollider.EnableDamageCollider();
            }

        }


        public void CloseDamageCollider()
        {
             if (rightHandDamageCollider != null)
            {
                rightHandDamageCollider.DisableDamageCollider();
            }

            if (leftHandDamageCollider != null)
            {
                leftHandDamageCollider.DisableDamageCollider();
            }
            //rightHandDamageCollider.DisableDamageCollider();
            //leftHandDamageCollider.DisableDamageCollider();
        }

        #endregion
        
        
        
        #region Handle Weapon's Stamina Drainage
        public void DrainStaminaLightAttack()
        {
             playerStats. TakeStaminaDamage (Mathf. RoundToInt(attackingWeapon.baseStamina * attackingWeapon.lightAttackMultiplier));
        }
       
        public void DrainStaminaHeavyAttack()
        {
             playerStats. TakeStaminaDamage (Mathf. RoundToInt(attackingWeapon.baseStamina * attackingWeapon.heavyAttackMultiplier));

        }
        #endregion

        public void EnableCombo()
        {
            //anim.SetBool ("canDoCombo", true);
        }

        public void DisableCombo()
        {
            //anim.SetBool ("canDoCombo", false);
        }
        
    }   

}