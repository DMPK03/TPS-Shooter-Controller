using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    public class WeaponSpecial : Weapon
    {
        [SerializeField] private Rigidbody rocketPrefab;
        
        public override void Fire()
        {
            Rigidbody rocket = Instantiate(rocketPrefab, muzzle.position, muzzle.rotation);
            rocket.velocity = transform.TransformDirection(Vector3.forward * 30f);
        }
    }
}