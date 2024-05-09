using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] AnimationClip clip;
    //public  float forwardSpeed;
    //public float sideSpeed; // Maybe set in the StateMachineController script for access everywhere??

    public override void EnterState()
    {
        animator.CrossFade(clip.name, .2f);
        animator.SetFloat("forwardMove", moveSpeed, .1f, Time.deltaTime); // Use for Idle as well
        animator.SetFloat("sideMove", moveSpeed, .1f, Time.deltaTime);
    }

    public override void StartState()
    {

        if (!groundCheck.isGrounded)
        {
            stateIsComplete = true;
            //animator.speed = sideSpeed;
        }
    }

    public override void ExitState() 
    {
    
    }
}
