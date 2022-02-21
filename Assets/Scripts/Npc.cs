using UnityEngine;

namespace Dmpk_TPS
{
    public class Npc : MonoBehaviour, IDamagable
    {
        [SerializeField] private protected GameObject impactEffect;
        [SerializeField] private protected int npcHealth;

        private protected Health health;
        private protected Animator animator;
        private protected Collider colider;
        
        private protected State state;

        private protected int hitHash, dieHash;

        private protected virtual void Awake()
        {
            animator = GetComponent<Animator>();
            colider = GetComponent<Collider>();

            HashAnims();
        }

        private protected virtual void Start()
        {
            health = new Health(npcHealth, 0);
            state = State.Idle;
            animator.SetInteger("Idle", Random.Range(0,3));
        }


        private protected virtual void HashAnims()
        {
            hitHash = Animator.StringToHash("Hit");
            dieHash = Animator.StringToHash("Die");
        }

        public virtual void TakeDamage(int damage, float force, RaycastHit hit)
        {
            if (health.Current != health.Min)
            {
                GameObject _impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));

                Destroy(_impact, .2f);

                animator.SetTrigger(hitHash);

                health.TakeDamage(damage);

                if(health.Current == health.Min)
                    Die();

            }
        }

        public virtual void Die()
        {
            animator.SetTrigger(dieHash);

            colider.enabled = false;

            Destroy(this.gameObject, 10);
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
