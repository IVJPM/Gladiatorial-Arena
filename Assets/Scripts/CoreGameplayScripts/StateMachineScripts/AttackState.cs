using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] AnimationClip attackAnimationClip;

    public override void EnterState()
    {
        if(attackAnimationClip != null )
        {
            animator.CrossFade(attackAnimationClip.name, .1f);
        }
        else
        {
            return;
        }
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

    public void SetAttackAnimation(AnimationClip attackAnimationClip)
    {
        this.attackAnimationClip = attackAnimationClip;
    }
}
