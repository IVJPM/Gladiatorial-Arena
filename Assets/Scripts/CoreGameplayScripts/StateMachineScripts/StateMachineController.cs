using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineController : MonoBehaviour
{
    public new Rigidbody rigidbody;

    public Animator animator;

    public PlayerMovement playerMovement;

    public GroundCheck groundCheck;

    public StateMachine stateMachine;

    public void SetUpStateInstances()
    {
        stateMachine = new StateMachine();
        State[] allChildStates = GetComponentsInChildren<State>();
        foreach (State state in allChildStates)
        {
            state.SetStateCore(this);
        }
    }
}
