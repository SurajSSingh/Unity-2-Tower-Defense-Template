using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyAction : StateMachineBehaviour
{
    public EnemyManager enemy;
    public GameObject target;
    public int speed;
    public int attackDamage;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.gameObject.GetComponent<EnemyManager>();
        target = enemy.currentTarget;
        speed = enemy.self.speed;
        attackDamage = enemy.self.damage;
    }
}
