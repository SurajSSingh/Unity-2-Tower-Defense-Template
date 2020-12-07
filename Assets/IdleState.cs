using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateMachineBehaviour
{
    TowerManager tm;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tm = animator.GetComponent<TowerManager>();
        tm.FindNextTarget();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (tm.currentTarget == null)
        {
            tm.FindNextTarget();
        }
        else
        {
            animator.SetBool("hasTarget", true);
        }
    }
}
