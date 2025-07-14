using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DodgeState : State
{
    [SerializeField] AnimationClip dodgeAnimationClip;
    [SerializeField] PlayerMovement playerMovement;

    public override void EnterState()
    {
        animator.CrossFade(dodgeAnimationClip.name, .1f);
    }

    public override void PerformState()
    {
        if (!groundCheck.isGrounded)
        {
            stateIsComplete = true;
        }
        playerMovement.HandleDodge();
    }

    public override void ExitState()
    {

    }
}
