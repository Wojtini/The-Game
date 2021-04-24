using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBcastingProjectiles : StateMachineBehaviour
{
    public GameObject projectile;
    public float waveCooldown = 1f;
    public float currWaveCooldown = 0f;
    public float speed = 5f;
    public int particleAmountPerWave = 3;
    private Transform target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(currWaveCooldown > 0)
        {
            currWaveCooldown -= Time.deltaTime;
            return;
        }
        currWaveCooldown = waveCooldown;

        for(int i = 0; i<particleAmountPerWave; i++)
        {
            Projectile go = Instantiate(projectile).GetComponent<Projectile>();
            go.transform.position = animator.gameObject.transform.position;
            go.setTarget(target,Random.Range(-10f,10f));
            go.setSpeed(speed);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
