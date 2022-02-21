using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Dmpk_TPS
{
    public class NpcRoaming : Npc
    {
        private protected int speedHash;
        private float idleTime = 10;
        private float stateEnterTime, targetSpeed;
        private float speed = 0;

        private NavMeshAgent agent;
        private Vector3 destination;

        private protected override void Start()
        {
            agent = GetComponent<NavMeshAgent>();

            animator.SetInteger("Idle", Random.Range(0,3));

            ChangeState(State.Idle, 0);
        }

        private protected override void HashAnims()
        {
            base.HashAnims();
            speedHash = Animator.StringToHash("Speed");
        }
        
        private protected bool PickDestination(out Vector3 target)
        {
            NavMeshPath path = new NavMeshPath();

            Vector3 randomDirection =  new Vector3(Random.Range(-1f,1f) ,0,  Random.Range(-1f,1f)).normalized;
            target = transform.position + randomDirection * Random.Range(3f, 8f);
            
            agent.CalculatePath(target, path);
            return(path.status == NavMeshPathStatus.PathComplete);
        }

        private void HandleIdle()
        {
            if ( Time.time > idleTime + stateEnterTime)
            {
                if(PickDestination(out destination))
                {
                    agent.destination = destination;
                    ChangeState(State.Roaming, 1);
                }
            }
        }

        private void HandleRoaming()
        {      
            if (agent.remainingDistance < 1 )
                ChangeState(State.Idle, 0);
        }
        
        public override void Die()
        {
            base.Die();
            
            agent.speed = 0;

            ChangeState(State.Dead, 0);
        }

        private void ChangeState(State newState, float speed)
        {
            stateEnterTime = Time.time;
            targetSpeed = speed;
            
            state = newState;
        }

        public virtual void Update()
        {
            float transition = idleTime * Time.deltaTime;
            
            speed = Mathf.MoveTowards(speed, targetSpeed, transition);
            animator.SetFloat(speedHash, speed);
            
            switch (state)
            {
                case State.Idle:
                HandleIdle();
                break;
                case State.Roaming:
                HandleRoaming();
                break;
                default:
                break;
            }
        }
    }

}

