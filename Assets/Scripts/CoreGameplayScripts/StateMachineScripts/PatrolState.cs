using UnityEngine;

public class PatrolState : State
{
    [SerializeField] NPCPatrol npcPatrol;
    [SerializeField] Animator characterAnimation;
    [SerializeField] AnimationClip walkClip;
    public override void EnterState()
    {
        npcPatrol.navMeshAgent.isStopped = false;

        npcPatrol.StartCoroutine(npcPatrol.PatrolPosition());

        
    }

    public override void PerformState()
    {
        npcPatrol.HandleCharacterMovement();
        
        if (!groundCheck.isGrounded)
        {
            stateIsComplete = true;
            //animator.speed = sideSpeed;
        }
    }

    public override void ExitState()
    {
        npcPatrol.navMeshAgent.isStopped = true;
        //npcPatrol.StopCoroutine(npcPatrol.PatrolPosition());
    }
}
