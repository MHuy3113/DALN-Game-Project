using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    public class CharacterManager : MonoBehaviour
    {
        [Header("Lock On Transform")]
        public Transform lockOnTransform;

        [Header("Combat Colliders")]
        public backStabCollider backStabCollider;
        public backStabCollider riposteCollider;

        [Header("Combat Flags")]
        public bool canBeRiposted;

        //DMG will be inficted during animation event
        
        public int pendingCriticalDamage;
        

    }
}
