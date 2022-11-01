using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endbehav : StateMachineBehaviour
{

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("exit");
        animator.gameObject.transform.position = new Vector3(animator.gameObject.transform.position.x, 
                                                            animator.gameObject.transform.position.y+1.8f, 
                                                            animator.gameObject.transform.position.z+1f);

        Debug.Log(animator.gameObject.transform.position);
        changeBoolClimb();
    }

    internal void OnStateExit(Animator animator, Rigidbody rb)
    {
        
        
    }
    public void changeBoolClimb()
    {
        movement Movement = GameObject.Find("MainCharacter1").GetComponent<movement>();
        Movement.Invoke("IsClimb", 0.25f);
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
