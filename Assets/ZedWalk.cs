using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZedWalk : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("Idle", Random.Range(0, 3));
    }


}
