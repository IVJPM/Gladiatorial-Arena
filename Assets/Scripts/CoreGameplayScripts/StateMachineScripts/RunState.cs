using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    [SerializeField] AnimationClip clip;
    [SerializeField] float forwardSpeed;
    [SerializeField] float sideSpeed;

    public override void EnterState()
    {
        animator.CrossFade(clip.name, .1f);
        animator.SetFloat("forwardMove", moveSpeed, .1f, Time.deltaTime); // Use for Idle as well
        animator.SetFloat("sideMove", moveSpeed, .1f, Time.deltaTime);
    }

    public override void StartState()
    {
        
        if (!groundCheck.isGrounded)
        {
            stateIsComplete = true;
        }

    }

    public override void ExitState()
    {

    }
}
