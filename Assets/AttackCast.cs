using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCast : StateMachineBehaviour
{
    public GameObject projectile;
    public Transform target;
    public float speed = 20f;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (projectile == null || target == null)
            return;
        GameObject a = Instantiate(projectile);
        a.transform.position = animator.transform.position;

        Projectile projComp = a.GetComponent<Projectile>();
        if (projComp == null)
            return;
        projComp.setSpeed(speed);
        projComp.setTarget(target,0f);
        //Vector3 targetPos = target.position;
        //Vector3 thisPos = a.transform.position;
        //targetPos.x = targetPos.x - thisPos.x;
        //targetPos.y = targetPos.y - thisPos.y;
        //float angle = Mathf.Atan2(targetPos.y, targetPos.x) * Mathf.Rad2Deg;
        //a.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + -90));
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
