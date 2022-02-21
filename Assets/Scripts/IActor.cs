using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dmpk_TPS
{
    public interface IActor 
    {
        public void TakeDamage(GameObject prefab, float force, RaycastHit hit);
        public void Die();

    }
}

