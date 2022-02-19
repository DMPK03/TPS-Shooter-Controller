using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    public class WeaponSpecial : WeaponRanged
    {
        public Rigidbody rocketPrefab;
        
        public override void Fire()
        {
            currentAmmo -=1;
            Rigidbody rocket = Instantiate(rocketPrefab, muzzle.position, muzzle.rotation);
            rocket.velocity = transform.TransformDirection(Vector3.forward * 25f);
        }
    }
}