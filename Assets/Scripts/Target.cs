using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{    
    [RequireComponent(typeof(Rigidbody))]
    public class Target : MonoBehaviour, IDamagable 
    {
        [SerializeField] private GameObject impactEffect;
        [SerializeField] private int targetHealth;
        
        private Rigidbody rb;
        private Health health;

        private void Awake() {
            health = new Health(targetHealth, 0);
            rb = GetComponent<Rigidbody>();
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        public void TakeDamage(int damage, float force, RaycastHit hit)
        {
            GameObject _impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

            Vector3 _impactForce = force * -hit.normal;
            rb.AddForce(_impactForce, ForceMode.Impulse);

            Destroy(_impact, .2f);

            health.TakeDamage(damage);

            if(health.Current == health.Min)
                    Die();
        }
    }
}