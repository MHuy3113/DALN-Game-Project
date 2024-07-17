using System.Collections;
using System.Collections.Generic;
using SG;
using UnityEngine;

namespace SG
{


    public class OpenChest : Interactable
    {
        public Transform playerStandingPosition;
        public override void Interact (PlayerManager playerManager)
        {
            Vector3 rotationDirection = transform.position - playerManager.transform.position;
            rotationDirection.y = 0;
            rotationDirection.Normalize();

            Quaternion tr = Quaternion.LookRotation (rotationDirection);
            Quaternion targetRotation = Quaternion.Slerp (playerManager.transform.rotation, tr, 300 * Time.deltaTime);
            playerManager.transform.rotation = targetRotation;
            //Lock his transform to a certain point infront of the chest
            //open the chest lid, and animate the player
            //spawn an item inside the chest the player can pick up

            
        }
    }
}