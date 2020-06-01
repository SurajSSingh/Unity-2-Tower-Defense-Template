using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindUnitScript : BaseEnemyAction
{
    EnemyScript enemy;
    GameObject currentTarget;

    //private void Awake()
    //{
    //    foreach (string objTag in enemy.targetTags)
    //    {
    //        if (GameObject.FindGameObjectsWithTag(objTag) != null)
    //        {
    //            currentTarget = GameObject.FindGameObjectsWithTag(objTag)[0];
    //        }
    //    }

    //    if (currentTarget == null)
    //    {
    //        currentTarget = GameObject.FindGameObjectWithTag("Player");
    //    }
    //}

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
