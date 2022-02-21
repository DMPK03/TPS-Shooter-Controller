using UnityEngine;

namespace Dmpk_TPS
{
    public interface IDamagable
    {
        public void TakeDamage(int damage, float force, RaycastHit hit);
        public void Die();
    }  
}

