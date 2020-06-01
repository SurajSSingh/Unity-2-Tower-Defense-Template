using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : BaseEnemyAction
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.transform.rotation = Quaternion.Slerp(enemy.transform.rotation,
            enemy.GetComponent<EnemyManager>().GetDir(),
            enemy.GetComponent<EnemyManager>().self.rotRate * Time.deltaTime);
        enemy.transform.Translate(0, speed * Time.deltaTime,0);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.transform.Translate(0, 0, 0);
    }
}
