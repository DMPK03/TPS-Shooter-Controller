using UnityEngine;

namespace Dmpk_TPS
{
    public interface IDamagable
    {
        public void Damage(int damage, float force, RaycastHit hit);
        public void Die();
    }  
}

