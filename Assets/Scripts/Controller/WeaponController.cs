using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dmpk_TPS
{
    public class WeaponController : MonoBehaviour
    {
        public static event Action<bool> SwitchWeapon, ReloadWeapon;
        
        [SerializeField] private List<Weapon> weapons = new List<Weapon>();
        [SerializeField] private Transform weaponAttach;

        private Weapon currentWeapon, selected;

        private bool fire, weaponReady = true;

        private void Awake() {
            InputManager.Switch += HandleInputSwitch;
            InputManager.Reloading += HandleInputReload;
            InputManager.Firing += f => fire = f;
        }

        void Start()
        {
            currentWeapon = weapons[0];
            currentWeapon.SetIk();
        }

        public void SwitchWeaponStart()
        {
            currentWeapon.gameObject.SetActive(false);

            currentWeapon = selected != null? selected : currentWeapon;

            currentWeapon.gameObject.SetActive(true);
            currentWeapon.SetIk();    
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
            return weapons.Count < 4 && weaponAttach.Find(weapon.name+"(Clone)") == null;
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


        void WallCheck()
        {
            /*LayerMask mask = LayerMask.GetMask("Enviroment");
            if (Physics.Raycast(weaponAttach.position, transform.forward, .7f, mask ))
            {
                animationControll.Wall(true);
                closeToWall = true;
            }
            else if (!Physics.Raycast(weaponAttach.position, transform.forward, 1f, mask ))
            {
                animationControll.Wall(false);
                closeToWall = false;
            }*/
        }
    }
}