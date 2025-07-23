using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NPCManager : StateMachineController
{
    NPCInteractions npcInteractions;
    NPCPatrol npcPatrol;

    [Header("Character States")]
    public State idleState; //Try [SerializeField] after making sure this works
    public State talkingState;
    public State patrolState;

    // Start is called before the first frame update
    void Start()
    {
        npcInteractions = GetComponent<NPCInteractions>();
        if(npcInteractions != null )
        {
            npcPatrol = GetComponent<NPCPatrol>();
        }
        else
        {
            return;
        }

            SetUpStateInstances();
        stateMachine.Set(idleState);
    }

    // Update is called once per frame
    void Update()
    {
        SetCharacterState();
        stateMachine.state.PerformState();
    }

    private void SetCharacterState()
    {
        if (groundCheck.isGrounded)
        {
           if(npcInteractions.IsInteracting() == true)
            {
                stateMachine.Set(talkingState);
            }
           else if(npcPatrol != null && npcInteractions.IsInteracting() == false)
            {
                stateMachine.Set(patrolState);
            }
           else
            {
                stateMachine.Set(idleState);
            }
        }
    }
}
