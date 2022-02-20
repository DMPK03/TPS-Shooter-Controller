using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dmpk_TPS
{
    public class WeaponRanged : Weapon
    {
        
        [SerializeField] private GameObject impactEffect;

        [SerializeField] private int weaponDamage;
        [SerializeField] private ParticleSystem muzzleFlashParticle, tracerParticle;

        public override void Fire()
        {      
            currentAmmo --;

            RaycastHit hit;
            
            tracerParticle.Play();
            muzzleFlashParticle.Play();
            cameraRecoil.GenerateImpulse(Camera.main.transform.forward);
            
            if (Physics.Raycast(muzzle.position, muzzle.forward, out hit))
            {
                if(hit.transform.TryGetComponent( out IDamagable target))
                {
                    target.Damage(weaponDamage, 5f, hit);
                }
                else
                {
                    GameObject _impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(_impact, .2f);
                }
            }

            if (source != null)
            {
                source.Play();
            }
        }
    }
}