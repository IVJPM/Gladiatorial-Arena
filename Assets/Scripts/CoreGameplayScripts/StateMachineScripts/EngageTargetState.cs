using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngageTargetState : State
{
    [SerializeField] AnimationClip engageAnimation;

    public override void EnterState()
    {

        if(!animator.GetNextAnimatorStateInfo(0).IsName(engageAnimation.name)) 
        animator.CrossFade(engageAnimation.name, .1f);
    }

    public override void PerformState()
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
