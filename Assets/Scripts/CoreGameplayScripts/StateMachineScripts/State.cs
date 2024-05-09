using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected StateMachineController controller;

    public Rigidbody body => controller.rigidbody;

    public Animator animator => controller.animator;

    public PlayerMovement playerMovement => controller.playerMovement;

    public GroundCheck groundCheck => controller.groundCheck;

    public bool stateIsComplete { get; protected set; }

    public float startTime;

    public float time => Time.time - startTime;

    public float moveSpeed;


    public virtual void EnterState() { }

    public virtual void StartState() { }

    //public virtual void Initialize() { }
    public virtual void ExitState() { }

   public void SetStateCore(StateMachineController controller) 
    {
        this.controller = controller;
    }

    public void Initialize()
    {
        stateIsComplete = false;
        startTime = Time.time;
    }
}
