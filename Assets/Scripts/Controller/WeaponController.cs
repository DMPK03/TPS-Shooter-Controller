using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dmpk_TPS
{
    public class WeaponController : MonoBehaviour
    {
        public static event Action<bool> SwitchWeapon, ReloadWeapon;
        public static event Action<string> Warning;
        
        [SerializeField] private List<Weapon> weapons = new List<Weapon>();
        [SerializeField] private Transform weaponAttach;

        private Weapon currentWeapon, selected;

        private bool fire, drop, weaponReady = true;

        private void Awake() {
            InputManager.Switch += HandleInputSwitch;
            InputManager.Reloading += HandleInputReload;
            InputManager.Drop += HandleInputDrop;
            InputManager.Firing += f => fire = f;
        }

        private void HandleInputDrop()
        {
            int index = weapons.IndexOf(currentWeapon);
            
            if( index != 0)
            {
                drop = true;
                HandleInputSwitch(index);

                weapons.Remove(currentWeapon);
                Rigidbody rb = currentWeapon.gameObject.AddComponent<Rigidbody>();
                currentWeapon.transform.SetParent(null);
                rb.AddForce(this.transform.forward * 3, ForceMode.Impulse);
                
                Destroy(currentWeapon.gameObject, 3);
            }
            else
            {
                Warning?.Invoke("Cant drop primary weapon");
            }    
        }

        void Start()
        {
            currentWeapon = weapons[0];
            currentWeapon.SetIk();
        }

        public void SwitchWeaponStart()
        {
            if(drop)
                drop = false;
            else
                currentWeapon.gameObject.SetActive(false);

            currentWeapon = selected != null? selected : currentWeapon;

            currentWeapon.gameObject.SetActive(true);
            currentWeapon.SetIk();
            currentWeapon.WeaponSelected();    
        }

        public void SwitchWeaponEnd()
        {
            SwitchWeapon?.Invoke(false);            
            weaponReady = true;
        }

        private void HandleInputSwitch(float i)
        {
            int index = (int)i - 1;
            if(index >= weapons.Count) return;

            if(weaponReady && weapons[index] != currentWeapon)
            {
                selected = weapons[index];
                weaponReady = false;
                SwitchWeapon?.Invoke(true);
            }
        }

        public bool CanPickUp(Weapon weapon)
        {
            if(weapons.Count < 4 && weaponAttach.Find(weapon.name+"(Clone)") == null)
            {
                return true;
            }
            else
            {
                Warning?.Invoke("No empty weapon slots, drop something");
                return false;    
            }
            
        }
        
        public void PickupWeapon(Weapon wpn)
        {
            GameObject spawn = Instantiate(wpn.gameObject, weaponAttach.transform, false);
            Weapon newWeapon = spawn.GetComponent<Weapon>();
 
            weapons.Add(newWeapon);
            newWeapon.gameObject.SetActive(false);
        }

        private bool CanAttack()
        {
            return fire && weaponReady;
        }

        private void HandleInputReload(bool r)
        {
            if(weaponReady && currentWeapon.CanReload())
            {
                weaponReady = false;
                currentWeapon.ReloadStart();
                ReloadWeapon?.Invoke(true);
            }        
        }

        public void ReloadFinished()
        {
            currentWeapon.ReloadEnd();
            weaponReady = true;
            ReloadWeapon?.Invoke(false);
        }

        void Update()
        {
            if(CanAttack())
               currentWeapon.FireWeapon();
        }

    }
}