using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonIdleBehaviour : StateMachineBehaviour
{
    public float currAttackCooldown = 0f;
    public float attackCooldown = 5f;
    public float attackDistance = 10f;
    public float currDistance;
    public Transform target;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        currAttackCooldown = 0f;

        currDistance = Vector2.Distance(target.transform.position, animator.gameObject.transform.position);
        if (currDistance >= attackDistance)
        {
            target = null;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        currAttackCooldown += Time.deltaTime;
    }
}
