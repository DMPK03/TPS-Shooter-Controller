using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    public class WeaponPickup : MonoBehaviour
    {
        [SerializeField] private Weapon weapon;
            
        private void OnTriggerEnter(Collider other)
        {
            if(other.TryGetComponent( out WeaponController weaponScript))
            {
                if(weaponScript.CanPickUp(weapon))
                {
                    weaponScript.PickupWeapon(weapon);
                    Destroy(this.gameObject);

                }
            }           
        }
    }
}