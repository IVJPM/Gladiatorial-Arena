using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] AnimationClip clip;

    public override void EnterState()
    {
        if (!animator.GetNextAnimatorStateInfo(0).IsName(clip.name))
        {
            AnimationsManager.instance.PlayAnimation(animator, clip, .1f);
        }
    }

    public override void PerformState()
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
