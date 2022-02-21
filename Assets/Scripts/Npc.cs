using UnityEngine;

namespace Dmpk_TPS
{
    public class Npc : MonoBehaviour, IActor
    {
        private protected Animator animator;
        private protected Collider colider;
        
        private protected State state;
        private protected int idleHash, hitHash, dieHash;
        
        private protected virtual void Awake()
        {
            animator = GetComponent<Animator>();
            colider = GetComponent<Collider>();

            HashAnims();
        }

        private protected virtual void Start()
        {            
            animator.SetInteger("Idle", Random.Range(0,3));
        }

        private protected virtual void HashAnims()
        {
            idleHash = Animator.StringToHash("Idle");
            hitHash = Animator.StringToHash("Hit");
            dieHash = Animator.StringToHash("Die");
        }

        public virtual void Die()
        {
            animator.SetTrigger(dieHash);

            colider.enabled = false;

            Destroy(this.gameObject, 10);
        }

        public void TakeDamage(GameObject prefab, float force, RaycastHit hit)
        {
            GameObject _impact = Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(_impact, .2f);
            
            animator.SetTrigger(hitHash);
        }
    }

    public enum State {
        Idle,
        Roaming,
        Chasing,
        Attacking,
        Dead,
    }
    
}
