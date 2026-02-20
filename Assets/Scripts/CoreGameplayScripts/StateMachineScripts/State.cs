using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateMachineController controller;

    public Rigidbody body => controller.rigidbody;

    public Animator animator => controller.animator;

    //public PlayerManager playerManager => controller.playerManager;

    public GroundCheck groundCheck => controller.groundCheck;

    public bool stateIsComplete { get; protected set; }

    public float startTime;

    public float time => Time.time - startTime;

    public virtual void EnterState() { }

    public virtual void PerformState() { }

    public virtual void ExitState() { startTime = 0; }

   public void SetStateCore(StateMachineController controller) 
    {
        this.controller = controller;
    }

    public virtual void PerformStateBranch()
    {
        PerformState();
        controller.stateMachine.state?.PerformStateBranch();
    }

    public void Initialize()
    {
        stateIsComplete = false;
        startTime = Time.time;
    }
}
