using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAction : StateMachineBehaviour
{
    public GameObject enemy;
    public GameObject target;
    public int speed;
    public int attackDamage;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject;
        target = enemy.GetComponent<EnemyManager>().currentTarget;
        speed = enemy.GetComponent<EnemyManager>().self.speed;
        attackDamage = enemy.GetComponent<EnemyManager>().self.damage;
    }
}
