using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] AnimationClip clip;

    public override void EnterState()
    {
        animator.CrossFade(clip.name, .2f);
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
