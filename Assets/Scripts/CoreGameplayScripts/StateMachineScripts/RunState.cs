using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
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
