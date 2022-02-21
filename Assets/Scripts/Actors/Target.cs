using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{    
    [RequireComponent(typeof(Rigidbody))]
    public class Target : MonoBehaviour, IActor 
    {       
        private Rigidbody rb;

        private void Awake() {
            rb = GetComponent<Rigidbody>();
        }

        public void Die()
        {
            Destroy(this.gameObject);
        }

        public void TakeDamage(GameObject prefab, float force, RaycastHit hit)
        {
            GameObject _impact = Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));

            Vector3 _impactForce = force * -hit.normal;
            rb.AddForce(_impactForce, ForceMode.Impulse);

            Destroy(_impact, .2f);
        }
    }
}