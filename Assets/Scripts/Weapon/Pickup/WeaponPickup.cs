using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    public class WeaponPickup : MonoBehaviour, IInteractable
    {        
        [SerializeField] private Weapon weapon;

        private string itemAction = "pickup";
        public string ItemAction => itemAction;

        public string ItemName => weapon.WeaponName;

        public Sprite ItemSprite => weapon.WeaponSprite;

        private bool pickup;

        private void OnTriggerEnter(Collider other)
        {
            Interact.Interactable(this, true);
            InputManager.Interact += p => pickup = p;         
        }

        private void OnTriggerExit(Collider other) {
            Interact.Interactable(this, false);
            InputManager.Interact -= p => pickup = p;
        }

        private void OnTriggerStay(Collider other)
        {
            if(pickup)
            {
                if(other.TryGetComponent( out WeaponController weaponScript))
                {
                    if(weaponScript.CanPickUp(weapon))
                    {
                        weaponScript.PickupWeapon(weapon);
                        Destroy(this.gameObject);
                    }
                }
                Interact.Interactable(this, false);
            }
            pickup = false;
        }
    }
}