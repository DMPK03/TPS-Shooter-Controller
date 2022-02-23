using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    public class RocketExplode : MonoBehaviour
    {
        [SerializeField]private Transform explosionPrefab;
        [SerializeField]private float radius;
        [SerializeField]private int rocketDamage;
        [SerializeField]private float force;

        private void OnCollisionEnter(Collision collision)
        {
            Destroy(this.gameObject);

            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;

            Instantiate(explosionPrefab, position, rotation);
            
            ExplosionDamage(position, radius);
        }

        void ExplosionDamage(Vector3 center, float radius)
        {
            Collider[] colliders = Physics.OverlapSphere(center, radius);
            
            foreach (var colider in colliders)
            {
                if(colider.transform.TryGetComponent( out IDamagable target))
                {                    
                    Vector3 direction = colider.transform.position - center;

                    if(Physics.Raycast(center, direction, out RaycastHit hit))
                    {
                        target.TakeDamage(rocketDamage, force, hit);
                    }
                }
            }
        }
    }

}
