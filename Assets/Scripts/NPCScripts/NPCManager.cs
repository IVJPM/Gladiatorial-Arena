using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCManager : StateMachineController
{
    NPCInteractions npcInteractions;

    [Header("Character States")]
    public State idleState; //Try [SerializeField] after making sure this works
    public State runState;
    public State attackState;
    public State talkingState;

    // Start is called before the first frame update
    void Start()
    {
        npcInteractions = GetComponent<NPCInteractions>();

        SetUpStateInstances();
        stateMachine.Set(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        SetCharacterState();
        stateMachine.state.StartState();
    }

    private void SetCharacterState()
    {
        if (groundCheck.isGrounded)
        {
           if(npcInteractions.IsInteracting() == true)
            {
                stateMachine.Set(talkingState);
            }
            else
            {
                stateMachine.Set(idleState);
            }
        }
    }
}
