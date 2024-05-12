using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingState : State
{
    [SerializeField] AnimationClip clip;

    public override void EnterState()
    {
        animator.CrossFade(clip.name, .1f);
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
