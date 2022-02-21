using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    public class Actor : MonoBehaviour, IDamagable
    {        
        [SerializeField] private protected GameObject impactEffect;
        [SerializeField] private protected int maxHealth = 100;

        [SerializeField] private protected bool useHealthBar;
        [SerializeField] private protected HealthBar healthBar;

        private protected Health health;
        private IActor actor;

        private void Awake()
        {
            actor = GetComponent<IActor>();
            useHealthBar = healthBar != null;
        }

        private void Start() {
            SetUpHealth();
        }

        private void SetUpHealth()
        {
            health = new Health(maxHealth);

            if(useHealthBar) healthBar.SetUpBar(maxHealth);
        }

        public void TakeDamage(int damage, float force, RaycastHit hit)
        {
            health.TakeDamage(damage);
            
            if(actor != null)
            {
                actor.TakeDamage(impactEffect, force, hit);
                
                if(health.Current == health.Min)
                    Die();
            }
                
            if(useHealthBar)
            {
                healthBar.gameObject.SetActive(true);
                healthBar.UpdateSlider(health.Current);
            }
        }

        private void Die()
        {
            actor.Die();
            if(useHealthBar)
                Destroy(healthBar.gameObject, .1f);
        }

    }
}

