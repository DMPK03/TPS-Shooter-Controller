using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Dmpk_TPS
{
    public class WeaponRanged : Weapon
    {
        
        [SerializeField] private GameObject impactEffect;
        [SerializeField] private GameObject bloodEffect;

        [SerializeField] private int weaponDamage;
        [SerializeField] private ParticleSystem muzzleFlashParticle, tracerParticle;

        public override void Fire()
        {      
            currentAmmo --;

            RaycastHit hit;
            GameObject impactPe;
            
            tracerParticle.Play();
            muzzleFlashParticle.Play();
            cameraRecoil.GenerateImpulse(Camera.main.transform.forward);
            
            if (Physics.Raycast(muzzle.position, muzzle.forward, out hit))
            {
                Health health = hit.transform.GetComponent<Health>();
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                if(health != null)
                {
                    impactPe = Instantiate(bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    health.takeDamage(weaponDamage);
                }
                else
                {
                    impactPe = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                    if (rb != null) rb.AddForce(0, 0, 5f, ForceMode.Impulse);
                }
                
                Destroy(impactPe, .2f);
            }
                if (source != null)
                {
                    source.Play();
                }
        }
    }
}