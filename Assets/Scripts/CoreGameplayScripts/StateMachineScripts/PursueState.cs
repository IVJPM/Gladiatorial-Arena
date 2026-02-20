using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursueState : State
{
    public float interval;
    public float intervalTracker;

    public AttackState attackState;
    public State engageTarget;
    public override void EnterState()
    {

    }

    public override void PerformState()
    {
        if (!groundCheck.isGrounded)
        {
            stateIsComplete = true;
        }
        
        if (intervalTracker >= interval)
        {
            controller.stateMachine.Set(attackState);
            StartCoroutine(EnemyAttackIntervals());
        }
        else
        {
            intervalTracker += Time.deltaTime;
            controller.stateMachine.Set(engageTarget);
        }
    }

    public override void ExitState()
    {
        
    }

    IEnumerator EnemyAttackIntervals()
    {
        if(animator.GetCurrentAnimatorStateInfo(0).IsName(attackState.GetAttackAnimationClip().name))
        {
            yield return new WaitUntil(() => animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1);
            intervalTracker = 0;
            interval = Random.Range(.2f, 4);
        }
    }
}
