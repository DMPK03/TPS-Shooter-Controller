using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    
    [RequireComponent(typeof(Rigidbody))]
    
    public class Box : MonoBehaviour, IDamagable 
    {
        [SerializeField] private GameObject impactEffect;
        
        private Rigidbody rb;
        private Health health;

        private void Awake() {
            health = new Health(100, 0, this);
            rb = GetComponent<Rigidbody>();
        }

        private void TakeHit(float force, RaycastHit hit)
        {
            GameObject _impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Vector3 _impactForce = force * -hit.normal;

            rb.AddForce(_impactForce, ForceMode.Impulse);

            Destroy(_impact, .2f);
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        public void Damage(int damage, float force, RaycastHit hit)
        {
            TakeHit(force, hit);
            health.TakeDamage(damage);
        }
    }
}